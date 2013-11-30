using System;

namespace ArtificialNeuralNetwork
{
	public class Range
	{
		#region Member Variables

		private float __maxValue;
		private float __minValue;
		private float __value;

		#endregion

		#region Initialization

		public void Init( float minValue, float maxValue, float value )
		{
			if ( value < minValue || value > maxValue )
				throw new ArgumentOutOfRangeException( "Initial setting for value is out of range!" );

			MaxValue = maxValue;
			MinValue = minValue;
			Value = value;
		}

		public Range( float minValue, float maxValue, float value )
		{
			Init( minValue, maxValue, value );
		}

		public Range()
		{
			Init( 0f, 1f, 0f );
		}

		#endregion

		#region Properties

		public float MaxValue
		{
			get { return __maxValue; }
			set
			{
				// Set the new maximum
				__maxValue = value;

				// Force the value to the new maximum if it's out of range
				if ( __maxValue < __value )
					Value = value;
			}
		}

		public float MinValue
		{
			get { return __minValue; }
			set
			{
				// Set the new minimum
				__minValue = value;

				// Force the value to the new minimum if it's out of range
				if ( __minValue > __value )
					Value = value;
			}
		}

		public float Value
		{
			get { return __value; }
			set
			{
				// Clamp the value into the range [min, max]
				if ( value < __minValue )
				{
					__value = __minValue;
				}
				else if ( value > __maxValue )
				{
					__value = __maxValue;
				}
				else
				{
					__value = value;
				}
			}
		}

		public float NormalizedValue
		{
			get { return ( __value - __minValue ) / ( __maxValue - __minValue ); }
			set { Value = ( __maxValue - __minValue ) * value + __minValue; }
		}

		#endregion
	}
}
