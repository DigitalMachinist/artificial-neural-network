using System;

namespace Perceptron
{
	public class Terminal
	{
		#region Member Variables

		public const float	VALUE_MAX			=  1.0f;
		public const float	VALUE_MIN			= -1.0f;
		public const float	WEIGHT_MAX			=  1.0f;
		public const float	WEIGHT_MIN			= -1.0f;
		public const float	WEIGHT_MAX_INITIAL	=  0.5f;
		public const float	WEIGHT_MIN_INITIAL	= -0.5f;

		private static Random sRandom;

		private Node	__input;
		private Node	__output;
		private float	__value;
		private float	__weight;

		#endregion

		#region Initialization

		public Terminal( Terminal clone )
		{
			Input = clone.Input;
			Output = clone.Output;
			Value = clone.Value;
			Weight = clone.Weight;
		}
		
		public Terminal( Node input, Node output, float value, float weight )
		{
			Input = input;
			Output = output;
			Value = value;
			Weight = weight;
		}
		
		public Terminal( Node input, Node output )
		{
			Input = input;
			Output = output;
			Value = 0f;
			Weight = GetRandomWeight( WEIGHT_MIN_INITIAL, WEIGHT_MAX_INITIAL );
		}
		
		public Terminal()
		{
			Input = null;
			Output = null;
			Value = 0f;
			Weight = GetRandomWeight( WEIGHT_MIN_INITIAL, WEIGHT_MAX_INITIAL );
		}

		#endregion

		#region Methods

		private float GetRandomWeight( float min, float max )
		{
			return (float)( ( max - min ) * sRandom.NextDouble() - min );
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
				if ( value > VALUE_MAX || value < VALUE_MIN )
				{
					throw new ArgumentOutOfRangeException( "Value must be bounded [" + VALUE_MIN + ", " + VALUE_MAX + "]!" );
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
				if ( value > WEIGHT_MAX || value < WEIGHT_MIN )
				{
					throw new ArgumentOutOfRangeException( "Weight must be bounded [" + WEIGHT_MIN + ", " + WEIGHT_MAX + "]!" );
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
