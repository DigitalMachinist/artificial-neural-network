using System;

namespace ArtificialNeuralNetwork
{
	public class MLP
	{
		#region Member Variables
		
		private Node[]	__hiddenLayer;
		private Node[]	__inputLayer;
		private Node[]	__outputLayer;
		private Range[]	__inputs;
		private Range[]	__outputs;
		private int		__trainingEpochs;
		private float	__trainingMeanSquaredError;
		private float	__trainingStep;
		private bool	__isReady;

		#endregion

		#region Initialization

		public void Init( int numInputLayer, int numHiddenLayer, int numOutputLayer, ActivationFunction activationFunction )
		{
			if ( numInputLayer < 1 )
				throw new ArgumentOutOfRangeException( "numInputLayer must be a value greater than 0!" );
			if ( numHiddenLayer < 1 )
				throw new ArgumentOutOfRangeException( "numHiddenLayer must be a value greater than 0!" );
			if ( numOutputLayer < 1 )
				throw new ArgumentOutOfRangeException( "numOutputLayer must be a value greater than 0!" );

			// Create input layer neurons
			InputLayer = new Node[ numInputLayer ];
			for ( int i = 0; i < numInputLayer; i++ )
				InputLayer[ i ] = new Node( 1, numHiddenLayer, activationFunction );

			// Create hidden layer neurons
			HiddenLayer = new Node[ numHiddenLayer ];
			for ( int i = 0; i < numHiddenLayer; i++ )
				HiddenLayer[ i ] = new Node( numInputLayer, numOutputLayer, activationFunction );

			// Create output layer neurons
			OutputLayer = new Node[ numOutputLayer ];
			for ( int i = 0; i < numOutputLayer; i++ )
				OutputLayer[ i ] = new Node( numHiddenLayer, 1, activationFunction );

			// Create input terminals for input layer neurons and the mapped input ranges
			Inputs = new Range[ numInputLayer ];
			for ( int i = 0; i < numInputLayer; i++ )
			{
				Inputs[ i ] = new Range();
				InputLayer[ i ].Inputs[ 0 ] = new Terminal( null, InputLayer[ i ], 0f, 1f );
			}

			// Create output terminals for output layer neurons and the mapped output ranges
			Outputs = new Range[ numOutputLayer ];
			for ( int i = 0; i < numOutputLayer; i++ )
			{
				Outputs[ i ] = new Range();
				OutputLayer[ i ].Outputs[ 0 ] = new Terminal( OutputLayer[ i ], null, 0f, 1f );
			}

			// Create terminals to link input layer neurons to hidden layer neurons
			for ( int i = 0; i < numInputLayer; i++ )
			{
				for ( int j = 0; j < numHiddenLayer; j++ )
				{
					Terminal terminal = new Terminal( InputLayer[ i ], HiddenLayer[ j ] );
					InputLayer[ i ].Outputs[ j ] = terminal;
					HiddenLayer[ j ].Inputs[ i ] = terminal;
				}
			}

			// Create terminals to link hidden layer neurons to output layer neurons
			for ( int i = 0; i < numHiddenLayer; i++ )
			{
				for ( int j = 0; j < numOutputLayer; j++ )
				{
					Terminal terminal = new Terminal( HiddenLayer[ i ], OutputLayer[ j ] );
					HiddenLayer[ i ].Outputs[ j ] = terminal;
					OutputLayer[ j ].Inputs[ i ] = terminal;
				}
			}

			// Flag this as ready
			IsReady = true;
		}

		public MLP( int numInputLayer, int numHiddenLayer, int numOutputLayer, ActivationFunction activationFunction = Node.ACT_FUNC_DEFAULT )
		{
			Init( numInputLayer, numHiddenLayer, numOutputLayer, activationFunction );
		}

		public MLP()
		{
			HiddenLayer = null;
			InputLayer = null;
			OutputLayer = null;
			Inputs = null;
			Outputs = null;
			IsReady = false;
		}

		#endregion

		#region Methods

		public void Train( TrainingSet[] data, float trainingStep, float maxMeanSquaredError, float minInitialWeight, float maxInitialWeight )
		{
			if ( !__isReady )
				throw new NotReadyException( "Init() must be called upon the MLP before it can be Train()ed!" );

			// Initialize the weights of the terminals from hidden->output to small values
			foreach ( Node node in OutputLayer )
				foreach ( Terminal terminal in node.Inputs )
					terminal.Weight = Helper.Random( minInitialWeight, maxInitialWeight );

			// Initialize the weights of the terminals from input->hidden to small values
			foreach ( Node node in HiddenLayer )
				foreach ( Terminal terminal in node.Inputs )
					terminal.Weight = Helper.Random( minInitialWeight, maxInitialWeight );

			// Initialize the training values
			__trainingEpochs = 0;
			__trainingMeanSquaredError = 10f * maxMeanSquaredError;
			__trainingStep = trainingStep;

			// Continue training until the error is small enough
			while ( __trainingMeanSquaredError > maxMeanSquaredError )
			{
				float squaredError = 0f;

				Range[] i = Inputs;
				Range[] o = Outputs;

				// For each training set, train the system
				for ( int j = 0; j < data.Length; j++ )
				{
					CopyTrainingSetToInputs( data[ j ] );
					Cycle();
					squaredError += TrainOutputLayer( data[ j ], trainingStep );
					TrainHiddenLayer( trainingStep );
				}

				__trainingMeanSquaredError = squaredError / data.Length;
				__trainingEpochs++;
			}
		}

		public float TrainOutputLayer( TrainingSet data, float trainingStep )
		{
			// For each node in the output layer
				// Compute the error between this node's output value and the target
				// Compute the weight adjustment for this node's inputs
				// For each input to this node
					// Add the computed amount to the weight of this input

			// Output layer error
			// outError = ( outTarget - outValue ) * outValue * ( 1 - outValue )

			// Output layer weight adjustment
			// outWeightChange = trainingStep * outError * hiddenValue

			float result = 0f;

			for ( int i = 0; i < __outputLayer.Length; i++ )
			{
				// Compute the error between the target and actual output values
				float outputValue = __outputLayer[ i ].Outputs[ 0 ].Value;
				float error = ( data.Outputs[ i ] - outputValue ); // * outputValue * ( 1f - outputValue );
				result += error * error;

				// Adjust the input weights for the current node
				__outputLayer[ i ].AdjustInputWeights( error, trainingStep );

				// Store the error in the input terminal to be used by the hidden layer training phase
				foreach ( Terminal input in __outputLayer[ i ].Inputs )
					input.Error = error;
			}

			return result;
		}

		public void TrainHiddenLayer( float trainingStep )
		{
			// For each node in the hidden layer
				// Compute the error between this node's output value and the target
				// Compute the weight adjustment for this node's inputs
				// For each input to this node
					// Add the computed amount to the weight of this input

			// Hidden layer error
			// hiddenError = hiddenValue * ( 1 - hiddenValue ) * SUM[0,k]( outError * outWeightChange )

			// Hidden layer weight adjustment
			// hiddenWeightChange = trainingStep * hiddenError * inputValue

			for ( int i = 0; i < __hiddenLayer.Length; i++ )
			{
				// Compute the sum of the weighted error for each output of this node
				float sumWeightedError = __hiddenLayer[ i ].GetSumOfWeightedOutputError();

				// Compute the error from the node value and the sum of the weighted error
				//float hiddenValue = __hiddenLayer[ i ].Outputs[ 0 ].Value;
				float hiddenError = sumWeightedError; // * hiddenValue * ( 1f - hiddenValue );

				// Adjust the input weights for the current node
				__hiddenLayer[ i ].AdjustInputWeights( hiddenError, trainingStep );
			}
		}

		public void Cycle()
		{
			if ( !__isReady )
				throw new NotReadyException( "Init() must be called upon the perceptron before it can be Cycle()d!" );

			CopyInputsToInputLayer();
			CycleInputLayer();
			CycleHiddenLayer();
			CycleOutputLayer();
			CopyOutputLayerToOutputs();
		}

		public void CycleInputLayer()
		{
			foreach ( Node node in __inputLayer )
				node.Cycle();
		}

		public void CycleHiddenLayer()
		{
			foreach ( Node node in __hiddenLayer )
				node.Cycle();
		}

		public void CycleOutputLayer()
		{
			foreach ( Node node in __outputLayer )
				node.Cycle();
		}

		public void CopyTrainingSetToInputs( TrainingSet data )
		{
			if ( __inputs.Length != data.Inputs.Length )
				throw new ArgumentException( "Training inputs differ in number from MLP inputs!" );

			for ( int i = 0; i < __inputs.Length; i++ )
				__inputs[ i ].Value = data.Inputs[ i ];
		}

		public void CopyInputsToInputLayer()
		{
			for ( int i = 0; i < __inputs.Length; i++ )
				__inputLayer[ i ].Inputs[ 0 ].Value = __inputs[ i ].NormalizedValue;
		}

		public void CopyOutputLayerToOutputs()
		{
			for ( int i = 0; i < __outputs.Length; i++ )
				__outputs[ i ].NormalizedValue = __outputLayer[ i ].Outputs[ 0 ].Value;
		}

		#endregion

		#region Properties

		public Range[] Inputs
		{
			get { return __inputs; }
			private set { __inputs = value; }
		}

		public Range[] Outputs
		{
			get { return __outputs; }
			private set { __outputs = value; }
		}

		public Node[] InputLayer
		{
			get { return __inputLayer; }
			private set { __inputLayer = value; }
		}

		public Node[] HiddenLayer
		{
			get { return __hiddenLayer; }
			private set { __hiddenLayer = value; }
		}

		public Node[] OutputLayer
		{
			get { return __outputLayer; }
			private set { __outputLayer = value; }
		}

		public int TrainingEpochs
		{
			get { return __trainingEpochs; }
			private set { __trainingEpochs = value; }
		}

		public float TrainingMeanSquaredError
		{
			get { return __trainingMeanSquaredError; }
			private set { __trainingMeanSquaredError = value; }
		}

		public float TrainingStep
		{
			get { return __trainingStep; }
			private set { __trainingStep = value; }
		}

		public bool IsReady
		{
			get { return __isReady; }
			private set { __isReady = value; }
		}

		#endregion
	}
}
