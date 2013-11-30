using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtificialNeuralNetwork;

namespace ArtificialNeuralNetworkTesting
{
	[TestClass]
	public class TerminalTest
	{
		/// <summary>
		/// Init() configures the terminal correctly.
		/// </summary>
		[TestMethod]
		public void TerminalInitInRange()
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
		/// Init() throws ArgumentOutOfRangeException for out-of-range Value.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void TerminalInitValueOutOfRange()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 1.5f, 0.1f );
		}

		/// <summary>
		/// Init() throws ArgumentOutOfRangeException for out-of-range Weight.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void TerminalInitWeightOutOfRange()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 1.1f );
		}

		/// <summary>
		/// 4-Arg constructor instantiation sets variables correctly with in-range Value.
		/// </summary>
		[TestMethod]
		public void TerminalConstructor4ArgsInRange()
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
		public void TerminalConstructor4ArgsValueOutOfRange()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 1.5f, 0.1f );
		}

		/// <summary>
		/// 4-Arg constructor instantiation throws ArgumentOutOfRangeException for out-of-range Weight.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void TerminalConstructor4ArgsWeightOutOfRange()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 1.1f );
		}

		/// <summary>
		/// 2-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void TerminalConstructor2Args()
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
		public void TerminalConstructor1Arg()
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
		public void TerminalConstructor0Args()
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
		public void TerminalGetInput()
		{
			Node input = new Node();
			Terminal testTerminal = new Terminal( input, new Node(), 0.5f, 0.1f );
			Assert.AreSame( input, testTerminal.Input, "Unexpected Terminal.Input" );
		}

		/// <summary>
		/// Output getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void TerminalGetOutput()
		{
			Node output = new Node();
			Terminal testTerminal = new Terminal( new Node(), output, 0.5f, 0.1f );
			Assert.AreSame( output, testTerminal.Output, "Unexpected Terminal.Output" );
		}

		/// <summary>
		/// Value getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void TerminalGetValue()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			Assert.AreEqual( 0.5f, testTerminal.Value, 0.001, "Unexpected Terminal.Value" );
		}

		/// <summary>
		/// Weight getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void TerminalGetWeight()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			Assert.AreEqual( 0.1f, testTerminal.Weight, 0.001, "Unexpected Terminal.Weight" );
		}

		/// <summary>
		/// WeightedValue getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void TerminalGetWeightedValue()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			Assert.AreEqual( 0.05f, testTerminal.WeightedValue, 0.001, "Unexpected Terminal.WeightedValue" );
		}

		/// <summary>
		/// Input setter correctly sets Input.
		/// </summary>
		[TestMethod]
		public void TerminalSetInput()
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
		public void TerminalSetOutput()
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
		public void TerminalSetValueInRange()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			testTerminal.Value = 0.8f;
			Assert.AreEqual( 0.8f, testTerminal.Value, "Unexpected Terminal.Value" );
		}

		/// <summary>
		/// Value setter clamps Value at the minimum when attempting to set Value too low.
		/// </summary>
		[TestMethod]
		public void TerminalSetValueOutOfRangeLow()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			testTerminal.Value = -0.5f;
			Assert.AreEqual( 0f, testTerminal.Value, "Unexpected Terminal.Value" );
		}

		/// <summary>
		/// Value setter clamps Value at the maximum when attempting to set Value too high.
		/// </summary>
		[TestMethod]
		public void TerminalSetValueOutOfRangeHigh()
		{
		Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			testTerminal.Value = 1.5f;
			Assert.AreEqual( 1f, testTerminal.Value, "Unexpected Terminal.Value" );
		}

		/// <summary>
		/// Weight setter correctly sets Weight if Weight is in-range.
		/// </summary>
		[TestMethod]
		public void TerminalSetWeightInRange()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			testTerminal.Weight = 0.3f;
			Assert.AreEqual( 0.3f, testTerminal.Weight, "Unexpected Terminal.Weight" );
		}

		/// <summary>
		/// Weight setter throws an ArgumentOfRangeException when setting Weight too low.
		/// </summary>
		[TestMethod]
		public void TerminalSetWeightOutOfRangeLow()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			testTerminal.Weight = -1.1f;
			Assert.AreEqual( -1f, testTerminal.Weight, "Unexpected Terminal.Weight" );
		}

		/// <summary>
		/// Weight setter throws an ArgumentOfRangeException when setting Weight too high.
		/// </summary>
		[TestMethod]
		public void TerminalSetWeightOutOfRangeHigh()
		{
			Terminal testTerminal = new Terminal( new Node(), new Node(), 0.5f, 0.1f );
			testTerminal.Weight = 1.1f;
			Assert.AreEqual( 1f, testTerminal.Weight, "Unexpected Terminal.Weight" );
		}
	}
}
