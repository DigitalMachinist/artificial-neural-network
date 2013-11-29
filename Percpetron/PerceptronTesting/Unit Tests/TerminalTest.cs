using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Perceptron;

namespace PerceptronTesting
{
	[TestClass]
	public class TerminalTest
	{
		/// <summary>
		/// 4-Arg constructor instantiation sets variables correctly with in-range Value.
		/// </summary>
		[TestMethod]
		public void Constructor4ArgsValueInRange()
		{
			Node input = new Node();
			Node output = new Node();
			Terminal testTerminal = new Terminal( input, output, 0.5f, 0.1f );
			Assert.AreSame( input, testTerminal.Input, "Unexpected Terminal.Input" );
			Assert.AreSame( output, testTerminal.Output, "Unexpected Terminal.Output" );
			Assert.AreEqual( 0.5f, testTerminal.Value, 0.001, "Unexpected Terminal.Value" );
			Assert.AreEqual( 0.1f, testTerminal.Weight, 0.001, "Unexpected Terminal.Weight" );
		}

		/// <summary>
		/// 4-Arg constructor instantiation throws ArgumentOutOfRangeException for out-of-range Value.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void Constructor4ArgsValueOutOfRange()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 1.5f, 0.1f );
		}

		/// <summary>
		/// 4-Arg constructor instantiation throws ArgumentOutOfRangeException for out-of-range Weight.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void Constructor4ArgsWeightOutOfRange()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 1.1f );
		}

		/// <summary>
		/// 2-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void Constructor2Args()
		{
			Node input = new Node();
			Node output = new Node();
			Terminal testTerminal = new Terminal( input, output );
			Assert.AreSame( input, testTerminal.Input, "Unexpected Terminal.Input" );
			Assert.AreSame( output, testTerminal.Output, "Unexpected Terminal.Output" );
			Assert.AreEqual( 0f, testTerminal.Value, 0.001, "Unexpected Terminal.Value" );
		}

		/// <summary>
		/// 1-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void Constructor1Arg()
		{
			Node input = new Node();
			Node output = new Node();
			Terminal cloneTerminal = new Terminal( input, output, 0.5f, 0.1f );
			Terminal testTerminal = new Terminal( cloneTerminal );
			Assert.AreSame( input, testTerminal.Input, "Unexpected Terminal.Input" );
			Assert.AreSame( output, testTerminal.Output, "Unexpected Terminal.Output" );
			Assert.AreEqual( 0.5f, testTerminal.Value, 0.001, "Unexpected Terminal.Value" );
			Assert.AreEqual( 0.1f, testTerminal.Weight, 0.001, "Unexpected Terminal.Weight" );
		}

		/// <summary>
		/// 0-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void Constructor0Args()
		{
			Terminal testTerminal = new Terminal();
			Assert.AreSame( null, testTerminal.Input, "Unexpected Terminal.Input" );
			Assert.AreSame( null, testTerminal.Output, "Unexpected Terminal.Output" );
			Assert.AreEqual( 0f, testTerminal.Value, 0.001, "Unexpected Terminal.Value" );
		}

		/// <summary>
		/// Input getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void GetInput()
		{
			Node input = new Node();
			Terminal testTerminal = new Terminal( input, new Node(), 0.5f, 0.1f );
			Assert.AreSame( input, testTerminal.Input, "Unexpected Terminal.Input" );
		}

		/// <summary>
		/// Output getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void GetOutput()
		{
			Node output = new Node();
			Terminal testTerminal = new Terminal( new Node(), output, 0.5f, 0.1f );
			Assert.AreSame( output, testTerminal.Output, "Unexpected Terminal.Output" );
		}

		/// <summary>
		/// Value getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void GetValue()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			Assert.AreEqual( 0.5f, testTerminal.Value, 0.001, "Unexpected Terminal.Value" );
		}

		/// <summary>
		/// Weight getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void GetWeight()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			Assert.AreEqual( 0.1f, testTerminal.Weight, 0.001, "Unexpected Terminal.Weight" );
		}

		/// <summary>
		/// WeightedValue getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void GetWeightedValue()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			Assert.AreEqual( 0.05f, testTerminal.WeightedValue, 0.001, "Unexpected Terminal.WeightedValue" );
		}

		/// <summary>
		/// Input setter correctly sets Input.
		/// </summary>
		[TestMethod]
		public void SetInput()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			Node input = new Node();
			testTerminal.Input = input;
			Assert.AreSame( input, testTerminal.Input, "Unexpected Terminal.Input" );
		}

		/// <summary>
		/// Output setter correctly sets Output.
		/// </summary>
		[TestMethod]
		public void SetOutput()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			Node output = new Node();
			testTerminal.Output = output;
			Assert.AreSame( output, testTerminal.Output, "Unexpected Terminal.Output" );
		}

		/// <summary>
		/// Value setter correctly sets Value if Value is in-range.
		/// </summary>
		[TestMethod]
		public void SetValueInRange()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			testTerminal.Value = 0.8f;
			Assert.AreEqual( 0.8f, testTerminal.Value, "Unexpected Terminal.Value" );
		}

		/// <summary>
		/// Value setter throws an ArgumentOfRangeException when setting Value too low.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void SetValueOutOfRangeLow()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			testTerminal.Value = -1.5f;
		}

		/// <summary>
		/// Value setter throws an ArgumentOfRangeException when setting Value too high.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void SetValueOutOfRangeHigh()
		{
		Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			testTerminal.Value = 1.5f;
		}

		/// <summary>
		/// Weight setter correctly sets Weight if Weight is in-range.
		/// </summary>
		[TestMethod]
		public void SetWeightInRange()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			testTerminal.Weight = 0.3f;
			Assert.AreEqual( 0.3f, testTerminal.Weight, "Unexpected Terminal.Weight" );
		}

		/// <summary>
		/// Weight setter throws an ArgumentOfRangeException when setting Weight too low.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void SetWeightOutOfRangeLow()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			testTerminal.Weight = 1.1f;
		}

		/// <summary>
		/// Weight setter throws an ArgumentOfRangeException when setting Weight too high.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void SetWeightOutOfRangeHigh()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			testTerminal.Weight = -1.1f;
		}
	}
}
