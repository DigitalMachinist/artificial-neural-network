using System;

namespace ArtificialNeuralNetwork
{
	public class Node
	{
		#region Member Variables

		public const ActivationFunction	ACT_FUNC_DEFAULT	= ActivationFunction.Threshold;
		public const float				BIAS_VALUE_DEFAULT	=  0f;
		public const float				BIAS_VALUE_MAX		=  1f;
		public const float				BIAS_VALUE_MIN		= -1f;

		private ActivationFunction	__activationFunction;
		private float				__biasValue;
		private Terminal[]			__inputs;
		private Terminal[]			__outputs;
		private bool				__isReady;

		#endregion

		#region Initialization

		public void Init( int numInputs, int numOutputs, ActivationFunction activationFunction = ACT_FUNC_DEFAULT, float biasValue = BIAS_VALUE_DEFAULT )
		{
			if ( numInputs < 1 )
				throw new ArgumentOutOfRangeException( "numInputs must be a value greater than 0!" );
			if ( numOutputs < 1 )
				throw new ArgumentOutOfRangeException( "numOutputs must be a value greater than 0!" );

			ActivationFunction = activationFunction;
			BiasValue = biasValue;
			Inputs = new Terminal[ numInputs ];
			Outputs = new Terminal[ numOutputs ];
			IsReady = true;
		}

		public Node( int numInputs, int numOutputs, ActivationFunction activationFunction = ACT_FUNC_DEFAULT, float biasValue = BIAS_VALUE_DEFAULT )
		{
			Init( numInputs, numOutputs, activationFunction, biasValue );
		}

		public Node( Node clone )
		{
			Init( clone.Inputs.Length, clone.Outputs.Length, clone.ActivationFunction, clone.BiasValue );
			
			for ( int i = 0; i < clone.Inputs.Length; i++ )
				Inputs[ i ] = clone.Inputs[ i ];

			for ( int i = 0; i < clone.Outputs.Length; i++ )
				Outputs[ i ] = clone.Outputs[ i ];
		}
		
		public Node()
		{
			ActivationFunction = ACT_FUNC_DEFAULT;
			BiasValue = BIAS_VALUE_DEFAULT;
			Inputs = null;
			Outputs = null;
			IsReady = false;
		}

		#endregion

		#region Methods

		public void Cycle()
		{
			if ( !__isReady ) 
				throw new NotReadyException( "Init() must be called upon the node before it can be Cycle()d!" );

			SetOutputValues( ComputeActivation( GetSumOfWeightedInputValues() ) + __biasValue );
		}

		public float GetSumOfWeightedInputValues()
		{
			float result = 0f;

			foreach ( Terminal input in __inputs )
			{
				if ( input == null )
					throw new ArgumentNullException( "Input terminals must be non-null to sum weighted input values!" );
				
				result += input.WeightedValue;
			}

			return result;
		}

		public float GetSumOfWeightedOutputError()
		{
			float result = 0f;

			foreach ( Terminal output in __outputs )
			{
				if ( output == null )
					throw new ArgumentNullException( "Output terminals must be non-null to weighted sum output error!" );

				result += output.WeightedError;
			}

			return result;
		}

		public float ComputeActivation( float inputSum )
		{
			switch ( __activationFunction )
			{
			case ActivationFunction.Threshold:			return Helper.Threshold( inputSum );
			case ActivationFunction.Sigmoid:			return Helper.Sigmoid( inputSum );
			case ActivationFunction.HyperbolicTangent:	return Helper.HyperbolicTangent( inputSum );
			default:									throw new ArgumentOutOfRangeException( "Unknown activation function!" );
			}
		}

		public void SetOutputValues( float value )
		{
			foreach ( Terminal output in __outputs )
			{
				if ( output == null )
					throw new ArgumentNullException( "Output terminals must be non-null to set output values!" );
				
				output.Value = value;
			}
		}

		public void AdjustInputWeights( float error, float trainingStep )
		{
			for ( int i = 0 ; i < Inputs.Length; i++ )
				Inputs[ i ].Weight += trainingStep * error * Inputs[ i ].Value;
		}

		#endregion

		#region Properties

		public ActivationFunction ActivationFunction
		{
			get { return __activationFunction; }
			set { __activationFunction = value; }
		}

		public float BiasValue
		{
			get { return __biasValue; }
			private set
			{
				if ( value < BIAS_VALUE_MIN || value > BIAS_VALUE_MAX )
					throw new ArgumentOutOfRangeException( "Bias value must be bounded [-1, 1]!" );

				__biasValue = value; 
			}
		}

		public Terminal[] Inputs
		{
			get { return __inputs; }
			private set { __inputs = value; }
		}

		public Terminal[] Outputs
		{
			get { return __outputs; }
			private set { __outputs = value; }
		}

		public bool IsReady
		{
			get { return __isReady; }
			private set { __isReady = value; }
		}

		#endregion
	}
}
