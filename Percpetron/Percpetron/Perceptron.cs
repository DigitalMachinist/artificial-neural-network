using System;
using System.Collections.Generic;

namespace Perceptron
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

		#endregion

		#region Initialization

		public Perceptron( int numInputs, ActivationFunction activationFunction = Node.ACT_FUNC_DEFAULT )
		{
			// Create a neuron
			__node = new Node( numInputs, 1, activationFunction );

			// Fill the node's input terminals
			__inputs = new Range[ numInputs ];
			for ( int i = 0; i < __node.Inputs.Length; i++ )
				__node.Inputs[ i ] = new Terminal( null, __node );

			// Provide the node with an output terminal
			__output = new Range();
			__node.Outputs[ 0 ] = new Terminal( __node, null );
		}

		#endregion

		#region Methods

		public void Train( TrainingSet[] data, float trainingStep, float maxMeanSquaredError )
		{
			__trainingEpochs = 0;
			float meanSquaredError = 10f * maxMeanSquaredError;

			// Continue looping until the condition is met, increasing i but looping it inside the range [0, data.Length]
			for ( int i = 0; Math.Abs( meanSquaredError - maxMeanSquaredError ) > 0.0001; i = ( i + 1 ) % data.Length )
			{
				float squaredError = 0f;

				// For each training set, train the system
				for ( int j = 0; j < data.Length; j++ )
				{
					CopyTrainingSetToInputs( data[ j ] );

					Cycle();

					float error = data[ j ].TargetOutputs[ 0 ] - __node.Outputs[ 0 ].Value;
					squaredError += error * error;

					AdjustNodeWeights( data[ j ], error );
				}

				// Compute the mean squared error for this epoch
				meanSquaredError = squaredError / data.Length;

				// Increment the epochs counter
				__trainingEpochs++;
			}
		}

		public void Cycle()
		{
			CopyInputsToNode();
			__node.Cycle();
			CopyOutputFromNode();
		}

		private void CopyTrainingSetToInputs( TrainingSet data )
		{
			if ( __inputs.Length != data.AppliedInputs.Length )
				throw new ArgumentOutOfRangeException( "Training inputs differ in number from node inputs!" );

			for ( int i = 0; i < __inputs.Length; i++ )
				__inputs[ i ].Value = data.AppliedInputs[ i ];
		}

		private void AdjustNodeWeights( TrainingSet data, float error )
		{
			for ( int i = 0 ; i < __inputs.Length; i++ )
				__node.Inputs[ i ].Weight = __node.Inputs[ i ].Weight + __trainingStep * error * __node.Inputs[ i ].Value;
		}

		private void CopyInputsToNode()
		{
			for ( int i = 0; i < __inputs.Length; i++ )
				__node.Inputs[ i ].Value = __inputs[ i ].NormalizedValue;
		}

		private void CopyOutputFromNode()
		{
			__output.NormalizedValue = __node.Outputs[ 0 ].Value;
		}

		#endregion

		#region Properties

		public Range[] Inputs
		{
			get { return __inputs; }
		}

		public Range Output
		{
			get { return __output; }
		}

		public Node	Node
		{
			get { return __node; }
		}

		public int TrainingEpochs
		{
			get { return __trainingEpochs; }
			set { __trainingEpochs = value; }
		}

		public float TrainingMeanSquaredError
		{
			get { return __trainingMeanSquaredError; }
			set { __trainingMeanSquaredError = value; }
		}

		public float TrainingStep
		{
			get { return __trainingStep; }
			set { __trainingStep = value; }
		}

		#endregion
	}
}
