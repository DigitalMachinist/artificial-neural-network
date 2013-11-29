using System;

namespace Perceptron
{
	public static class Helper
	{
		private static Random sRandom;

		static Helper()
		{
			sRandom = new Random();
		}

		public static float Random( float min, float max )
		{
			return (float)( ( max - min ) * sRandom.NextDouble() + min );
		}
	}
}
