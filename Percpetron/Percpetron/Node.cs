using System;

namespace Perceptron
{
	public class Node
	{
		#region Member Variables

		public const ActivationFunction	ACT_FUNC_DEFAULT	= ActivationFunction.Threshold;
		public const float				BIAS_VALUE_DEFAULT	= 0f;

		private ActivationFunction	__activationFunction;
		private Terminal			__bias;
		private Terminal[]			__inputs;
		private Terminal[]			__outputs;
		private bool				__isReady;

		#endregion

		#region Initialization

		public void Init( int numInputs, int numOutputs, ActivationFunction activationFunction = ACT_FUNC_DEFAULT, float biasValue = BIAS_VALUE_DEFAULT )
		{
			__activationFunction = activationFunction;
			__bias = new Terminal( null, this, biasValue, 1f );
			__inputs = new Terminal[ numInputs ];
			__outputs = new Terminal[ numOutputs ];
			__isReady = true;
		}

		public Node( Node clone )
		{
			Init( clone.Inputs.Length, clone.Outputs.Length, clone.ActivationFunction, clone.Bias.Value );
		}

		public Node( int numInputs, int numOutputs, ActivationFunction activationFunction = ACT_FUNC_DEFAULT, float biasValue = BIAS_VALUE_DEFAULT )
		{
			Init( numInputs, numOutputs, activationFunction, biasValue );
		}
		
		public Node()
		{
			__activationFunction = ACT_FUNC_DEFAULT;
			__bias = null;
			__inputs = null;
			__outputs = null;
			__isReady = false;
		}

		#endregion

		#region Methods

		public void Cycle()
		{
			if ( !__isReady ) 
				throw new NotReadyException( "Init() must be called upon a node before it can be Cycle()d!" );

			float inputSum = GetInputWeightedSum();
			float biasValue = ( __bias == null ) ? 0f : __bias.Value;
			float output = GetActivationFunctionOutput( inputSum ) + biasValue;
			SetOutputs( output );
		}

		private float GetInputWeightedSum()
		{
			float result = 0f;

			foreach ( Terminal input in __inputs )
			{
				if ( input != null )
				{
					result += input.WeightedValue;
				}
				else
				{
					throw new ArgumentNullException( "Input terminals must be non-null to sum input values!" );
				}
			}

			return result;
		}

		private float GetActivationFunctionOutput( float inputSum )
		{
			float result = 0f;

			switch ( __activationFunction )
			{
			
			// f(x) = ( x < 0 ) ? 0 : 1
			case ActivationFunction.Threshold:
			
				result = ( inputSum < 0f ) ? 0f : 1f;		
				break;

				
			// f(x) = 1 / ( e ^ -x + 1 )
			case ActivationFunction.Sigmoid:
			
				float exponential1 = (float)Math.Exp( -inputSum );
				result = 1f / ( exponential1 + 1f );
				break;

			
			// f(x) = ( e ^ 2x - 1 ) / ( e ^ 2x + 1 )
			case ActivationFunction.HyperbolicTangent:	

				float exponential2 = (float)Math.Exp( 2f * inputSum );
				result = ( exponential2 - 1 ) / ( exponential2 + 1 );
				break;

			}

			return result;
		}

		private void SetOutputs( float value )
		{
			foreach ( Terminal output in __outputs )
			{
				if ( output != null )
				{
					output.Value = value;
				}
				else
				{
					throw new ArgumentNullException( "Output terminals must be non-null to set output values!" );
				}
			}
		}

		#endregion

		#region Properties

		public ActivationFunction ActivationFunction
		{
			get { return __activationFunction; }
			set { __activationFunction = value; }
		}

		public Terminal Bias
		{
			get { return __bias; }
		}

		public Terminal[] Inputs
		{
			get { return __inputs; }
		}

		public Terminal[] Outputs
		{
			get { return __outputs; }
		}

		public bool IsReady
		{
			get { return __isReady; }
			set { __isReady = value; }
		}

		#endregion
	}
}
