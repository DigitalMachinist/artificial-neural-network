using System;

namespace ArtificialNeuralNetwork
{
	public static class Helper
	{
		#region Member Variables

		private static Random sRandom;

		#endregion

		#region Initialization

		static Helper()
		{
			sRandom = new Random();
		}

		#endregion

		#region Math

		public static float Random( float min, float max )
		{
			return (float)( ( max - min ) * sRandom.NextDouble() + min );
		}

		public static float Threshold( float x )
		{
			// f(x) = ( x < 0 ) ? -1 : 1
			return ( x < 0f ) ? 0f : 1f;
		}

		public static float Sigmoid( float x )
		{
			// f(x) = 1 / ( 1 + e^-x )
			float exponential = (float)Math.Exp( -x  );
			return 1f / ( 1f + exponential );
		}

		public static float HyperbolicTangent( float x )
		{
			// f(x) = 0.5 * ( 1 + ( e^x - e^-x ) / ( e^x + e^-x ) )
			float posExp = (float)Math.Exp(  x  );
			float negExp = (float)Math.Exp( -x  );
			return 0.5f * ( 1f + ( posExp - negExp ) / ( posExp + negExp ) );
		}
	
		#endregion

		#region Utilities

		public static void ConnectNodes( Node nodeProvidingOutput, int outputIndex, Node nodeAcceptingInput, int inputIndex )
		{
			Terminal terminal = new Terminal( nodeProvidingOutput, nodeAcceptingInput );
			nodeProvidingOutput.Outputs[ outputIndex ] = terminal;
			nodeAcceptingInput.Inputs[ inputIndex ] = terminal;
		}

		public static void DisconnectNodes( Node nodeProvidingOutput, int outputIndex, Node nodeAcceptingInput, int inputIndex )
		{
			nodeProvidingOutput.Outputs[ outputIndex ] = null;
			nodeAcceptingInput.Inputs[ inputIndex ] = null;
		}

		#endregion
	}
}
