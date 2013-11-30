using System;

namespace ArtificialNeuralNetwork
{
	public class TrainingSet
	{
		#region Member Variables

		private float[]	__inputs;
		private float[] __outputsExpected;

		#endregion

		#region Initialization

		public void Init( float[] inputs, float[] outputs )
		{
			Inputs = inputs;
			Outputs = outputs;
		}

		public void Init( int numInputs, int numOutputs )
		{
			if ( numInputs < 1 )
				throw new ArgumentOutOfRangeException( "numInputs must be a value greater than 0!" );
			if ( numOutputs < 1 )
				throw new ArgumentOutOfRangeException( "numOutputs must be a value greater than 0!" );

			Inputs = new float[ numInputs ];
			Outputs = new float[ numOutputs ];
		}

		public TrainingSet( float[] inputs, float[] outputs )
		{
			Init( inputs, outputs );
		}

		public TrainingSet( int numInputs, int numOutputs )
		{
			Init( numInputs, numOutputs );
		}

		public TrainingSet()
		{
			Inputs = null;
			Outputs = null;
		}

		#endregion

		#region Properties

		public float[] Inputs
		{
			get { return __inputs; }
			set { __inputs = value; }
		}

		public float[] Outputs
		{
			get { return __outputsExpected; }
			set { __outputsExpected = value; }
		}

		#endregion
	}
}
