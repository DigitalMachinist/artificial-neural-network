using System;

namespace Perceptron
{
	public class TrainingSet
	{
		#region Member Variables

		private float[]	__appliedInputs;
		private float[] __targetOutputs;

		#endregion

		#region Initialization

		public TrainingSet( int numInputs, int numOutputs )
		{
			__appliedInputs = new float[ numInputs ];
			__targetOutputs = new float[ numOutputs ];
		}

		#endregion

		#region Properties

		public float[] AppliedInputs
		{
			get { return __appliedInputs; }
		}

		public float[] TargetOutputs
		{
			get { return __targetOutputs; }
		}

		#endregion
	}
}
