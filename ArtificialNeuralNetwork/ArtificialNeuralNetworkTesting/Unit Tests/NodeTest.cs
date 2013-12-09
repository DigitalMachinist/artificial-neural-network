using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtificialNeuralNetwork;

namespace ArtificialNeuralNetworkTesting
{
	[TestClass]
	public class NodeTest
	{
		/// <summary>
		/// Init() configures the node correctly.
		/// </summary>
		[TestMethod]
		public void NodeInit()
		{
			Node testNode = new Node();
			testNode.Init( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			Assert.AreEqual( ActivationFunction.Sigmoid, testNode.ActivationFunction, "Unexpected Node.ActivationFunction" );
			Assert.AreEqual( 0.5f, testNode.BiasValue, "Unexpected Node.BiasValue" );
			Assert.AreNotSame( null, testNode.Inputs, "Unexpected Node.Inputs" );
			Assert.AreEqual( 2, testNode.Inputs.Length, "Unexpected Node.Inputs.Length" );
			Assert.AreNotSame( null, testNode.Outputs, "Unexpected Node.Outputs" );
			Assert.AreEqual( 1, testNode.Outputs.Length, "Unexpected Node.Outputs.Length" );
			Assert.AreEqual( true, testNode.IsReady, "Unexpected Node.IsReady" );
		}
		
		/// <summary>
		/// Init() throws ArgumentOutOfRangeException for out-of-range numInputs.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void NodeInitBiasNumInputsOutOfRange()
		{
			Node testNode = new Node();
			testNode.Init( -1, 1, ActivationFunction.Sigmoid, 0.5f );
		}
		
		/// <summary>
		/// Init() throws ArgumentOutOfRangeException for out-of-range numOutputs.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void NodeInitBiasNumOutputsOutOfRange()
		{
			Node testNode = new Node();
			testNode.Init( 2, -1, ActivationFunction.Sigmoid, 0.5f );
		}
		
		/// <summary>
		/// Init() throws ArgumentOutOfRangeException for out-of-range Bias.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void NodeInitBiasValueOutOfRange()
		{
			Node testNode = new Node();
			testNode.Init( 2, 1, ActivationFunction.Sigmoid, 1.5f );
		}

		/// <summary>
		/// 4-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void NodeConstructor4Arg()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			Assert.AreEqual( ActivationFunction.Sigmoid, testNode.ActivationFunction, "Unexpected Node.ActivationFunction" );
			Assert.AreEqual( 0.5f, testNode.BiasValue, "Unexpected Node.BiasValue" );
			Assert.AreNotSame( null, testNode.Inputs, "Unexpected Node.Inputs" );
			Assert.AreEqual( 2, testNode.Inputs.Length, "Unexpected Node.Inputs.Length" );
			Assert.AreNotSame( null, testNode.Outputs, "Unexpected Node.Outputs" );
			Assert.AreEqual( 1, testNode.Outputs.Length, "Unexpected Node.Outputs.Length" );
			Assert.AreEqual( true, testNode.IsReady, "Unexpected Node.IsReady" );
		}
		
		/// <summary>
		/// 4-Arg constructor instantiation throws ArgumentOutOfRangeException for out-of-range numInputs.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void NodeConstructor4ArgBiasNumInputsOutOfRange()
		{
			Node testNode = new Node( -1, 1, ActivationFunction.Sigmoid, 0.5f );
		}
		
		/// <summary>
		/// 4-Arg constructor instantiation throws ArgumentOutOfRangeException for out-of-range numOutputs.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void NodeConstructor4ArgBiasNumOutputsOutOfRange()
		{
			Node testNode = new Node( 2, -1, ActivationFunction.Sigmoid, 0.5f );
		}
		
		/// <summary>
		/// 4-Arg constructor instantiation throws ArgumentOutOfRangeException for out-of-range Bias.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void NodeConstructor4ArgBiasValueOutOfRange()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 1.5f );
		}

		/// <summary>
		/// 1-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void NodeConstructor1Arg()
		{
			Node cloneNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			Node testNode = new Node( cloneNode );
			Assert.AreEqual( ActivationFunction.Sigmoid, testNode.ActivationFunction, "Unexpected Node.ActivationFunction" );
			Assert.AreEqual( 0.5f, testNode.BiasValue, "Unexpected Node.BiasValue" );
			Assert.AreNotSame( null, testNode.Inputs, "Unexpected Node.Inputs" );
			Assert.AreEqual( 2, testNode.Inputs.Length, "Unexpected Node.Inputs.Length" );
			Assert.AreNotSame( null, testNode.Outputs, "Unexpected Node.Outputs" );
			Assert.AreEqual( 1, testNode.Outputs.Length, "Unexpected Node.Outputs.Length" );
			Assert.AreEqual( true, testNode.IsReady, "Unexpected Node.IsReady" );
		}

		/// <summary>
		/// 0-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void NodeConstructor0Arg()
		{
			Node testNode = new Node();
			Assert.AreEqual( Node.ACT_FUNC_DEFAULT, testNode.ActivationFunction, "Unexpected Node.ActivationFunction" );
			Assert.AreEqual( 0f, testNode.BiasValue, "Unexpected Node.BiasValue" );
			Assert.AreSame( null, testNode.Inputs, "Unexpected Node.Inputs" );
			Assert.AreSame( null, testNode.Outputs, "Unexpected Node.Outputs" );
			Assert.AreEqual( false, testNode.IsReady, "Unexpected Node.IsReady" );
		}

		/// <summary>
		/// Cycle() correctly sets the outputs of the node given a set of input values and weights.
		/// </summary>
		[TestMethod]
		public void NodeCycle()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Threshold, 0f );
			testNode.Inputs[ 0 ] = new Terminal( null, testNode, 0.75f, 1f );
			testNode.Inputs[ 1 ] = new Terminal( null, testNode, 0.25f, 1f );
			testNode.Outputs[ 0 ] = new Terminal( testNode, null, 0f, 1f );
			testNode.Cycle();
			Assert.AreEqual( 1f, testNode.Outputs[ 0 ].Value, "Unexpected Node.Outputs.Value" );
		}

		/// <summary>
		/// Cycle() throws a NotReadyException if called when IsReady = false.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArtificialNeuralNetwork.NotReadyException ) )]
		public void NodeCycleNotReady()
		{
			Node testNode = new Node();
			testNode.Cycle();
		}

		/// <summary>
		/// GetWeightedSumOfInputValues() correctly sums all input WeightedValue properties.
		/// </summary>
		[TestMethod]
		public void NodeGetWeightedSumOfInputValues()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			testNode.Inputs[ 0 ] = new Terminal( null, testNode, 0.75f, 1f );
			testNode.Inputs[ 1 ] = new Terminal( null, testNode, 0.25f, 1f );
			float test = testNode.GetSumOfWeightedInputValues();
			Assert.AreEqual( 1f, test, "Unexpected weighted sum result" );
		}

		/// <summary>
		/// GetWeightedSumOfInputValues() throws an ArgumentOfRangeException when any of the inputs is null.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void NodeGetWeightedSumOfInputValuesNullInput()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			float test = testNode.GetSumOfWeightedInputValues();
		}

		/// <summary>
		/// ComputeActivation() correctly computes the activation function output for the Threshold function.
		/// </summary>
		[TestMethod]
		public void NodeComputeActivationThreshold()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Threshold, 0f );
			testNode.Inputs[ 0 ] = new Terminal( null, testNode, 1.0f,  1f );
			testNode.Inputs[ 1 ] = new Terminal( null, testNode, 0.5f, -1f );
			float test = testNode.ComputeActivation( testNode.GetSumOfWeightedInputValues() );
			Assert.AreEqual( 1.0000f, test, 0.001, "Unexpected Node.Outputs.Value" );
		}

		/// <summary>
		/// ComputeActivation() correctly computes the activation function output for the Sigmoid function.
		/// </summary>
		[TestMethod]
		public void NodeComputeActivationSigmoid()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0f );
			testNode.Inputs[ 0 ] = new Terminal( null, testNode, 1.0f,  1f );
			testNode.Inputs[ 1 ] = new Terminal( null, testNode, 0.5f, -1f );
			Assert.AreEqual( 0.5f, testNode.GetSumOfWeightedInputValues(), 0.001, "Unexpected Node.GetWeightedSumOfInputValues()" );
			float test = testNode.ComputeActivation( testNode.GetSumOfWeightedInputValues() );
			Assert.AreEqual( 0.6225f, test, 0.001, "Unexpected Node.Outputs.Value" );
		}

		/// <summary>
		/// ComputeActivation() correctly computes the activation function output for the Hyperbolic Tangent function.
		/// </summary>
		[TestMethod]
		public void NodeComputeActivationHyperbolicTangent()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.HyperbolicTangent, 0f );
			testNode.Inputs[ 0 ] = new Terminal( null, testNode, 1.0f,  1f );
			testNode.Inputs[ 1 ] = new Terminal( null, testNode, 0.5f, -1f );
			Assert.AreEqual( 0.5f, testNode.GetSumOfWeightedInputValues(), 0.001, "Unexpected Node.GetWeightedSumOfInputValues()" );
			float test = testNode.ComputeActivation( testNode.GetSumOfWeightedInputValues() );
			Assert.AreEqual( 0.7311f, test, 0.001, "Unexpected Node.Outputs.Value" );
		}

		/// <summary>
		/// NodeSetOutputValues() correctly sets all output Value properties to the specified value.
		/// </summary>
		[TestMethod]
		public void NodeSetOutputValues()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			testNode.Outputs[ 0 ] = new Terminal( testNode, null, 0f, 1f );
			testNode.SetOutputValues( 1f );
			Assert.AreEqual( 1f, testNode.Outputs[ 0 ].Value, 0.001, "Unexpected Node.Outputs[ 0 ].Value" );
		}

		/// <summary>
		/// AdjustInputWeights() correctly adjusts the weights of all input terminals given a training
		/// step and a value for error at the output terminal.
		/// </summary>
		[TestMethod]
		public void NodeAdjustInputWeights()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			testNode.Inputs[ 0 ] = new Terminal( null, testNode, 0.1f, 0.1f );
			testNode.Inputs[ 1 ] = new Terminal( null, testNode, 0.1f, 0.2f );
			testNode.Outputs[ 0 ] = new Terminal( testNode, null, 0f, 1f );
			testNode.AdjustInputWeights( 1f, 1f );
			Assert.AreEqual( 0.2f, testNode.Inputs[ 0 ].Weight, 0.001, "Unexpected Node.Inputs[ 0 ].Weight" );
			Assert.AreEqual( 0.3f, testNode.Inputs[ 1 ].Weight, 0.001, "Unexpected Node.Inputs[ 1 ].Weight" );
		}

		/// <summary>
		/// NodeSetOutputValues() throws an ArgumentOfRangeException when any of the outputs is null.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void NodeSetOutputsNullOutput()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			testNode.SetOutputValues( 1f );
		}

		/// <summary>
		/// ActivationFunction getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void NodeGetActivationFunction()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			Assert.AreEqual( ActivationFunction.Sigmoid, testNode.ActivationFunction, "Unexpected Node.ActivationFunction" );
		}

		/// <summary>
		/// Bias getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void NodeGetBias()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			Assert.AreEqual( 0.5f, testNode.BiasValue, 0.001, "Unexpected Node.BiasValue" );
		}

		/// <summary>
		/// Inputs getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void NodeGetInputs()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			Assert.AreNotSame( null, testNode.Inputs, "Node.Inputs unexpectedly null" );
			Assert.AreEqual( 2, testNode.Inputs.Length, 0.001, "Unexpected Node.Inputs.Length" );
		}

		/// <summary>
		/// Outputs getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void NodeGetOutputs()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			Assert.AreNotSame( null, testNode.Outputs, "Node.Outputs unexpectedly null" );
			Assert.AreEqual( 1, testNode.Outputs.Length, 0.001, "Unexpected Node.Outputs.Length" );
		}

		/// <summary>
		/// IsReady getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void NodeGetIsReady()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			Assert.AreEqual( true, testNode.IsReady, "Unexpected Node.IsReady" );
		}

		/// <summary>
		/// ActivationFunction setter correctly sets ActivationFunction.
		/// </summary>
		[TestMethod]
		public void NodeSetActivationFunction()
		{
			Node testNode = new Node( 2, 1, ActivationFunction.Sigmoid, 0.5f );
			testNode.ActivationFunction = ActivationFunction.HyperbolicTangent;
			Assert.AreEqual( ActivationFunction.HyperbolicTangent, testNode.ActivationFunction, "Unexpected Node.ActivationFunction" );
		}
	}
}
