using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtificialNeuralNetwork;

namespace ArtificialNeuralNetworkTesting
{
	[TestClass]
	public class RangeTest
	{
		/// <summary>
		/// Init() configures the range correctly.
		/// </summary>
		[TestMethod]
		public void RangeInitInRange()
		{
			Range testRange = new Range();
			testRange.Init( 1f, 9f, 5f );
			Assert.AreEqual( 1f, testRange.MinValue, 0.001, "Unexpected Range.MinValue" );
			Assert.AreEqual( 9f, testRange.MaxValue, 0.001, "Unexpected Range.MaxValue" );
			Assert.AreEqual( 5f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}

		/// <summary>
		/// Init() throws ArgumentOutOfRangeException for out-of-range Value.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void RangeInitValueOutOfRange()
		{
			Range testRange = new Range();
			testRange.Init( 1f, 9f, 10f );
		}
		
		/// <summary>
		/// 4-Arg constructor instantiation sets variables correctly with in-range value.
		/// </summary>
		[TestMethod]
		public void RangeConstructor4ArgsValueInRange()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			Assert.AreEqual( 1f, testRange.MinValue, 0.001, "Unexpected Range.MinValue" );
			Assert.AreEqual( 9f, testRange.MaxValue, 0.001, "Unexpected Range.MaxValue" );
			Assert.AreEqual( 5f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}
		
		/// <summary>
		/// 4-Arg constructor instantiation throws ArgumentOutOfRangeException for out-of-range Value.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void RangeConstructor4ArgsValueOutOfRange()
		{
			Range testRange = new Range( 1f, 9f, 10f );
		}
		
		/// <summary>
		/// 0-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void RangeConstructor0Args()
		{
			Range testRange = new Range();
			Assert.AreEqual( 0f, testRange.MinValue, 0.001, "Unexpected Range.MinValue" );
			Assert.AreEqual( 1f, testRange.MaxValue, 0.001, "Unexpected Range.MaxValue" );
			Assert.AreEqual( 0f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}
		
		/// <summary>
		/// MaxValue getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void RangeGetMaxValue()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			Assert.AreEqual( 9f, testRange.MaxValue, 0.001, "Unexpected Range.MaxValue" );
		}
		
		/// <summary>
		/// MinValue getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void RangeGetMinValue()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			Assert.AreEqual( 1f, testRange.MinValue, 0.001, "Unexpected Range.MinValue" );
		}
		
		/// <summary>
		/// Value getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void RangeGetValue()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			Assert.AreEqual( 5f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}
		
		/// <summary>
		/// NormalizedValue getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void RangeGetNormalizedValue()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			Assert.AreEqual( 0.5f, testRange.NormalizedValue, 0.001, "Unexpected Range.NormalizedValue" );
		}
		
		/// <summary>
		/// MaxValue setter correctly sets MaxValue and does not change Value if Value is in-range.
		/// </summary>
		[TestMethod]
		public void RangeSetMaxValueValueInRange()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.MaxValue = 10f;
			Assert.AreEqual( 10f, testRange.MaxValue, 0.001, "Unexpected Range.MaxValue" );
			Assert.AreEqual( 5f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}
		
		/// <summary>
		/// MaxValue setter correctly sets MaxValue and forces Value in-range when the Value
		/// would be out-of-range with respect to the bounds specified by the new MaxValue.
		/// </summary>
		[TestMethod]
		public void RangeSetMaxValueValueOutOfRange()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.MaxValue = 4f;
			Assert.AreEqual( 4f, testRange.MaxValue, 0.001, "Unexpected Range.MaxValue" );
			Assert.AreEqual( 4f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}

		/// <summary>
		/// MinValue setter correctly sets MinValue and does not change Value if Value is in-range.
		/// </summary>
		[TestMethod]
		public void RangeSetMinValueValueInRange()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.MinValue = 0f;
			Assert.AreEqual( 0f, testRange.MinValue, 0.001, "Unexpected Range.MinValue" );
			Assert.AreEqual( 5f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}

		/// <summary>
		/// MinValue setter correctly sets MinValue and forces Value in-range when the Value
		/// would be out-of-range with respect to the bounds specified by the new MinValue.
		/// </summary>
		[TestMethod]
		public void RangeSetMinValueValueOutOfRange()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.MinValue = 6f;
			Assert.AreEqual( 6f, testRange.MinValue, 0.001, "Unexpected Range.MinValue" );
			Assert.AreEqual( 6f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}

		/// <summary>
		/// Value setter correctly sets Value if Value is in-range.
		/// </summary>
		[TestMethod]
		public void RangeSetValueInRange()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.Value = 6f;
			Assert.AreEqual( 6f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}

		/// <summary>
		/// Value setter sets Value to the maximum when attempting to set Value too low.
		/// </summary>
		[TestMethod]
		public void RangeSetValueOutOfRangeLow()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.Value = 0f;
			Assert.AreEqual( 1f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}

		/// <summary>
		/// Value setter sets Value to the maximum when attempting to set Value too high.
		/// </summary>
		[TestMethod]
		public void RangeSetValueOutOfRangeHigh()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.Value = 10f;
			Assert.AreEqual( 9f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}

		/// <summary>
		/// NormalizedValue setter correctly sets Value if NormalizedValue is in-range.
		/// </summary>
		[TestMethod]
		public void RangeSetNormalizedValue()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.NormalizedValue = 0.75f;
			Assert.AreEqual( 7f, testRange.Value, 0.001, "Unexpected Range.Value" );
			Assert.AreEqual( 0.75f, testRange.NormalizedValue, 0.001, "Unexpected Range.NormalizedValue" );
		}

		/// <summary>
		/// NormalizedValue setter sets Value to the minimum when attempting to set Value too low.
		/// </summary>
		[TestMethod]
		public void RangeSetNormalizedValueOutOfRangeLow()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.NormalizedValue = 1.25f;
			Assert.AreEqual( 9f, testRange.Value, 0.001, "Unexpected Range.Value" );
			Assert.AreEqual( 1f, testRange.NormalizedValue, 0.001, "Unexpected Range.NormalizedValue" );
		}

		/// <summary>
		/// NormalizedValue setter sets Value to the maximum when attempting to set Value too high.
		/// </summary>
		[TestMethod]
		public void RangeSetNormalizedValueOutOfRangeHigh()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.NormalizedValue = -0.25f;
			Assert.AreEqual( 1f, testRange.Value, 0.001, "Unexpected Range.Value" );
			Assert.AreEqual( 0f, testRange.NormalizedValue, 0.001, "Unexpected Range.NormalizedValue" );
		}
	}
}
