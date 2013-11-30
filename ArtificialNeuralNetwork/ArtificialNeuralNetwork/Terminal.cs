using System;

namespace ArtificialNeuralNetwork
{
	public class Terminal
	{
		#region Member Variables

		public const float	VALUE_MAX			=  1.0f;
		public const float	VALUE_MIN			=  0.0f;
		public const float	WEIGHT_MAX			=  1.0f;
		public const float	WEIGHT_MIN			= -1.0f;
		public const float	WEIGHT_MAX_INITIAL	=  0.5f;
		public const float	WEIGHT_MIN_INITIAL	= -0.5f;

		private Node	__input;
		private Node	__output;
		private float	__value;
		private float	__weight;

		#endregion

		#region Initialization
		
		public void Init( Node input, Node output, float value = 0f, float weight = 1f )
		{
			if ( value > VALUE_MAX || value < VALUE_MIN )
				throw new ArgumentOutOfRangeException( "Value must be bounded [" + VALUE_MIN + ", " + VALUE_MAX + "]!" );
			if ( weight > WEIGHT_MAX || weight < WEIGHT_MIN )
				throw new ArgumentOutOfRangeException( "Weight must be bounded [" + WEIGHT_MIN + ", " + WEIGHT_MAX + "]!" );

			Input = input;
			Output = output;
			Value = value;
			Weight = weight;
		}

		public Terminal( Node input, Node output, float value, float weight )
		{
			Init( input, output, value, weight );
		}
		
		public Terminal( Node input, Node output )
		{
			Init( input, output );
		}

		public Terminal( Terminal clone )
		{
			Init( clone.Input, clone.Output, clone.Value, clone.Weight );
		}
		
		public Terminal()
		{
			Init( null, null );
		}

		#endregion

		#region Properties

		public Node Input
		{
			get { return __input; }
			set { __input = value; }
		}

		public Node Output
		{
			get { return __output; }
			set { __output = value; }
		}

		public float Value
		{
			get { return __value; }
			set
			{
				//if ( value > VALUE_MAX || value < VALUE_MIN )
				//	throw new ArgumentOutOfRangeException( "Value must be bounded [" + VALUE_MIN + ", " + VALUE_MAX + "]!" );
				//
				//__value = value;

				// Clamp the value to the bounds [VALUE_MIN, VALUE_MAX]
				if ( value > VALUE_MAX )
				{
					__value = VALUE_MAX;
				}
				else if ( value < VALUE_MIN )
				{
					__value = VALUE_MIN;
				}
				else
				{
					__value = value;
				}
			}
		}

		public float Weight
		{
			get { return __weight; }
			set
			{
				//if ( value > WEIGHT_MAX || value < WEIGHT_MIN )
				//	throw new ArgumentOutOfRangeException( "Weight must be bounded [" + WEIGHT_MIN + ", " + WEIGHT_MAX + "]!" );
				//
				//__weight = value;

				// Clamp the weight to the bounds [WEIGHT_MIN, WEIGHT_MAX]
				if ( value > WEIGHT_MAX )
				{
					__weight = WEIGHT_MAX;
				}
				else if ( value < WEIGHT_MIN )
				{
					__weight = WEIGHT_MIN;
				}
				else
				{
					__weight = value;
				}
			}
		}

		public float WeightedValue
		{
			get { return __weight * __value; }
		}

		#endregion
	}
}
