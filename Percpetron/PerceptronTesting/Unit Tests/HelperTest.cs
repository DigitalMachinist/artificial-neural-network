using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Perceptron;

namespace PerceptronTesting
{
	[TestClass]
	public class HelperTest
	{
		/// <summary>
		/// Test whether random value remains within the bounds [min, max] for 1000 repetitions.
		/// </summary>
		[TestMethod]
		public void Random()
		{
			for ( int i = 0; i < 1000; i++ )
			{
				float test = Helper.Random( 2f, 8f );
				
				if ( test < 2f || test > 8f )
					Assert.Fail( "Random value (" + test + ") created out of bounds [2, 8]" );
			}
		}
	}
}
