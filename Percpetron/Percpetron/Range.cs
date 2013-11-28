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
			__maxValue = maxValue;
			__minValue = minValue;
			__value = value;
		}

		public Range()
		{
			__maxValue = 1f;
			__minValue = 0f;
			__value = 0f;
		}

		#endregion

		#region Properties

		public float MaxValue
		{
			get { return __maxValue; }
			set { __maxValue = value; }
		}

		public float MinValue
		{
			get { return __minValue; }
			set { __minValue = value; }
		}

		public float Value
		{
			get { return __value; }
			set
			{
				if ( value > __maxValue || value < __minValue )
				{
					throw new ArgumentOutOfRangeException( "Value out of range for the defined bounds [" + MinValue + ", " + MaxValue + "]!" );
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
			set
			{
				float result = ( __maxValue - __minValue ) * value + __minValue;
				
				if ( result > __maxValue || result < __minValue )
				{
					throw new ArgumentOutOfRangeException( "Value out of range for the defined bounds [" + MinValue + ", " + MaxValue + "]!" );
				}
				else
				{
					__value = result;
				}
			}
		}

		#endregion
	}
}
