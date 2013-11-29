using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Perceptron;

namespace PerceptronTesting
{
	[TestClass]
	public class RangeTest
	{
		/// <summary>
		/// 4-Arg constructor instantiation sets variables correctly with in-range value.
		/// </summary>
		[TestMethod]
		public void Constructor4ArgsValueInRange()
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
		public void Constructor4ArgsValueOutOfRange()
		{
			Range testRange = new Range( 1f, 9f, 10f );
		}
		
		/// <summary>
		/// 0-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void Constructor0Args()
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
		public void GetMaxValue()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			Assert.AreEqual( 9f, testRange.MaxValue, 0.001, "Unexpected Range.MaxValue" );
		}
		
		/// <summary>
		/// MinValue getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void GetMinValue()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			Assert.AreEqual( 1f, testRange.MinValue, 0.001, "Unexpected Range.MinValue" );
		}
		
		/// <summary>
		/// Value getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void GetValue()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			Assert.AreEqual( 5f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}
		
		/// <summary>
		/// NormalizedValue getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void GetNormalizedValue()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			Assert.AreEqual( 0.5f, testRange.NormalizedValue, 0.001, "Unexpected Range.NormalizedValue" );
		}
		
		/// <summary>
		/// MaxValue setter correctly sets MaxValue and does not change Value if Value is in-range.
		/// </summary>
		[TestMethod]
		public void SetMaxValueValueInRange()
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
		public void SetMaxValueValueOutOfRange()
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
		public void SetMinValueValueInRange()
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
		public void SetMinValueValueOutOfRange()
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
		public void SetValueInRange()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.Value = 6f;
			Assert.AreEqual( 6f, testRange.Value, 0.001, "Unexpected Range.Value" );
		}

		/// <summary>
		/// Value setter throws an ArgumentOfRangeException when setting Value too low.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void SetValueOutOfRangeLow()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.Value = 0f;
		}

		/// <summary>
		/// Value setter throws an ArgumentOfRangeException when setting Value too high.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void SetValueOutOfRangeHigh()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.Value = 10f;
		}

		/// <summary>
		/// NormalizedValue setter correctly sets Value if NormalizedValue is in-range.
		/// </summary>
		[TestMethod]
		public void SetNormalizedValueInRange()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.NormalizedValue = 0.75f;
			Assert.AreEqual( 7f, testRange.Value, 0.001, "Unexpected Range.Value" );
			Assert.AreEqual( 0.75f, testRange.NormalizedValue, 0.001, "Unexpected Range.NormalizedValue" );
		}

		/// <summary>
		/// NormalizedValue setter throws an ArgumentOfRangeException when setting Value too low.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void SetNormalizedValueOutOfRangeLow()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.NormalizedValue = 1.25f;
		}

		/// <summary>
		/// NormalizedValue setter throws an ArgumentOfRangeException when setting Value too high.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void SetNormalizedValueOutOfRangeHigh()
		{
			Range testRange = new Range( 1f, 9f, 5f );
			testRange.NormalizedValue = -0.25f;
		}
	}
}
