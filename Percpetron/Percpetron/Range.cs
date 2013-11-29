using System;

namespace Perceptron
{
	public class Range
	{
		#region Member Variables

		private float __maxValue;
		private float __minValue;
		private float __value;

		#endregion

		#region Initialization

		public Range( float minValue, float maxValue, float value )
		{
			MaxValue = maxValue;
			MinValue = minValue;
			Value = value;
		}

		public Range()
		{
			MaxValue = 1f;
			MinValue = 0f;
			Value = 0f;
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
					__value = value;
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
					__value = value;
			}
		}

		public float Value
		{
			get { return __value; }
			set
			{
				if ( value > __maxValue || value < __minValue )
					throw new ArgumentOutOfRangeException( "Value out of range for the defined bounds [" + MinValue + ", " + MaxValue + "]!" );
				
				__value = value;
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
