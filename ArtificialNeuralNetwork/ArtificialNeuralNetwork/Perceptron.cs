using System;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork
{
	public class Perceptron
	{
		#region Member Variables
		
		private Range[]	__inputs;
		private Range	__output;
		private Node	__node;
		private int		__trainingEpochs;
		private float	__trainingMeanSquaredError;
		private float	__trainingStep;
		private bool	__isReady;

		#endregion

		#region Initialization

		public void Init( int numInputs, ActivationFunction activationFunction )
		{
			if ( numInputs < 1 )
				throw new ArgumentOutOfRangeException( "numInputs must be a value greater than 0!" );

			// Create a neuron
			Node = new Node( numInputs, 1, activationFunction );

			// Fill the node's input terminals
			Inputs = new Range[ numInputs ];
			for ( int i = 0; i < numInputs; i++ )
			{
				Inputs[ i ] = new Range();
				__node.Inputs[ i ] = new Terminal( null, __node );
			}

			// Provide the node with an output terminal
			Output = new Range();
			__node.Outputs[ 0 ] = new Terminal( __node, null );

			// Flag this as ready
			IsReady = true;
		}

		public Perceptron( int numInputs, ActivationFunction activationFunction = Node.ACT_FUNC_DEFAULT )
		{
			Init( numInputs, activationFunction );
		}

		public Perceptron()
		{
			Node = null;
			Inputs = null;
			Output = null;
			IsReady = false;
		}

		#endregion

		#region Methods

		public void Train( TrainingSet[] data, float trainingStep, float maxMeanSquaredError, float minInitialWeight, float maxInitialWeight )
		{
			if ( !__isReady )
				throw new NotReadyException( "Init() must be called upon the perceptron before it can be Train()ed!" );

			// Initialize the node input weights to small values
			foreach ( Terminal input in __node.Inputs )
				input.Weight = Helper.Random( minInitialWeight, maxInitialWeight );

			// Initialize the training values
			__trainingEpochs = 0;
			__trainingMeanSquaredError = 10f * maxMeanSquaredError;
			__trainingStep = trainingStep;

			// Continue training until the error is small enough
			while ( __trainingMeanSquaredError > maxMeanSquaredError )
			{
				float squaredError = 0f;

				// For each training set, train the system
				for ( int j = 0; j < data.Length; j++ )
				{
					CopyTrainingSetToInputs( data[ j ] );

					Cycle();

					float error = data[ j ].Outputs[ 0 ] - __node.Outputs[ 0 ].Value;
					squaredError += error * error;

					__node.AdjustInputWeights( error, __trainingStep );
				}

				__trainingMeanSquaredError = squaredError / data.Length;
				__trainingEpochs++;
			}
		}

		public void Cycle()
		{
			if ( !__isReady )
				throw new NotReadyException( "Init() must be called upon the perceptron before it can be Cycle()d!" );

			CopyInputsToNodeValues();
			__node.Cycle();
			CopyNodeValueToOutput();
		}

		public void CopyTrainingSetToInputs( TrainingSet data )
		{
			if ( __inputs.Length != data.Inputs.Length )
				throw new ArgumentException( "Training inputs differ in number from node inputs!" );

			for ( int i = 0; i < __inputs.Length; i++ )
				__inputs[ i ].Value = data.Inputs[ i ];
		}

		public void CopyInputsToNodeValues()
		{
			for ( int i = 0; i < __inputs.Length; i++ )
				__node.Inputs[ i ].Value = __inputs[ i ].NormalizedValue;
		}

		public void CopyNodeValueToOutput()
		{
			__output.NormalizedValue = __node.Outputs[ 0 ].Value;
		}

		#endregion

		#region Properties

		public Range[] Inputs
		{
			get { return __inputs; }
			private set { __inputs = value; }
		}

		public Range Output
		{
			get { return __output; }
			private set { __output = value; }
		}

		public Node	Node
		{
			get { return __node; }
			private set { __node = value; }
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
