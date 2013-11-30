using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtificialNeuralNetwork;

namespace ArtificialNeuralNetworkTesting
{
	[TestClass]
	public class HelperTest
	{
		/// <summary>
		/// Test whether random value remains within the bounds [min, max] for 1000 repetitions.
		/// </summary>
		[TestMethod]
		public void HelperRandom()
		{
			for ( int i = 0; i < 1000; i++ )
			{
				float test = Helper.Random( 2f, 8f );
				
				if ( test < 2f || test > 8f )
					Assert.Fail( "Random value (" + test + ") created out of bounds [2, 8]" );
			}
		}

		/// <summary>
		/// Test whether threshold function output is correct for a range of values.
		/// </summary>
		[TestMethod]
		public void HelperThreshold()
		{
			// f(x) = ( x < 0 ) ? 0 : 1
			Assert.AreEqual( 0.0000f, Helper.Threshold( -1.0f ), 0.001, "Unexpected threshold function output" );
			Assert.AreEqual( 0.0000f, Helper.Threshold( -0.6f ), 0.001, "Unexpected threshold function output" );
			Assert.AreEqual( 0.0000f, Helper.Threshold( -0.2f ), 0.001, "Unexpected threshold function output" );
			Assert.AreEqual( 1.0000f, Helper.Threshold(  0.0f ), 0.001, "Unexpected threshold function output" );
			Assert.AreEqual( 1.0000f, Helper.Threshold(  0.2f ), 0.001, "Unexpected threshold function output" );
			Assert.AreEqual( 1.0000f, Helper.Threshold(  0.6f ), 0.001, "Unexpected threshold function output" );
			Assert.AreEqual( 1.0000f, Helper.Threshold(  1.0f ), 0.001, "Unexpected threshold function output" );
		}

		/// <summary>
		/// Test whether sigmoid function output is correct for a range of values.
		/// </summary>
		[TestMethod]
		public void HelperSigmoid()
		{
			// f(x) = 1 / ( 1 + e^-x )
			Assert.AreEqual( 0.2689f, Helper.Sigmoid( -1.0f ), 0.001, "Unexpected sigmoid function output" );
			Assert.AreEqual( 0.3543f, Helper.Sigmoid( -0.6f ), 0.001, "Unexpected sigmoid function output" );
			Assert.AreEqual( 0.4502f, Helper.Sigmoid( -0.2f ), 0.001, "Unexpected sigmoid function output" );
			Assert.AreEqual( 0.5000f, Helper.Sigmoid(  0.0f ), 0.001, "Unexpected sigmoid function output" );
			Assert.AreEqual( 0.5498f, Helper.Sigmoid(  0.2f ), 0.001, "Unexpected sigmoid function output" );
			Assert.AreEqual( 0.6457f, Helper.Sigmoid(  0.6f ), 0.001, "Unexpected sigmoid function output" );
			Assert.AreEqual( 0.7311f, Helper.Sigmoid(  1.0f ), 0.001, "Unexpected sigmoid function output" );
		}

		/// <summary>
		/// Test whether hyperbolic tange function output is correct for a range of values.
		/// </summary>
		[TestMethod]
		public void HelperHyperbolicTangent()
		{
			// f(x) = 0.5 * ( 1 + ( e^x - e^-x ) / ( e^x + e^-x ) )
			Assert.AreEqual( 0.1192f, Helper.HyperbolicTangent( -1.0f ), 0.001, "Unexpected hyperbolic tangent function output" );
			Assert.AreEqual( 0.2315f, Helper.HyperbolicTangent( -0.6f ), 0.001, "Unexpected hyperbolic tangent function output" );
			Assert.AreEqual( 0.4013f, Helper.HyperbolicTangent( -0.2f ), 0.001, "Unexpected hyperbolic tangent function output" );
			Assert.AreEqual( 0.5000f, Helper.HyperbolicTangent(  0.0f ), 0.001, "Unexpected hyperbolic tangent function output" );
			Assert.AreEqual( 0.5987f, Helper.HyperbolicTangent(  0.2f ), 0.001, "Unexpected hyperbolic tangent function output" );
			Assert.AreEqual( 0.7685f, Helper.HyperbolicTangent(  0.6f ), 0.001, "Unexpected hyperbolic tangent function output" );
			Assert.AreEqual( 0.8808f, Helper.HyperbolicTangent(  1.0f ), 0.001, "Unexpected hyperbolic tangent function output" );
		}

		/// <summary>
		/// ConnectNodes() connects 2 nodes correctly.
		/// </summary>
		[TestMethod]
		public void HelperConnectNodes()
		{
			Node testNode1 = new Node( 2, 1 );
			Node testNode2 = new Node( 2, 1 );
			Helper.ConnectNodes( testNode1, 0, testNode2, 1 );
			Assert.AreSame( testNode2, testNode1.Outputs[ 0 ].Output, "Unexpected Node.Outputs[ 0 ].Output" );
			Assert.AreSame( testNode1, testNode2.Inputs[ 1 ].Input, "Unexpected Node.Inputs[ 1 ].Input" );
		}

		/// <summary>
		/// DisconnectNodes() disconnects 2 nodes correctly.
		/// </summary>
		[TestMethod]
		public void HelperDisconnectNodes()
		{
			Node testNode1 = new Node( 2, 1 );
			Node testNode2 = new Node( 2, 1 );
			Helper.ConnectNodes( testNode1, 0, testNode2, 1 );
			Assert.AreSame( testNode2, testNode1.Outputs[ 0 ].Output, "Unexpected Node.Outputs[ 0 ].Output" );
			Assert.AreSame( testNode1, testNode2.Inputs[ 1 ].Input, "Unexpected Node.Inputs[ 1 ].Input" );
			Helper.DisconnectNodes( testNode1, 0, testNode2, 1 );
			Assert.AreSame( null, testNode1.Outputs[ 0 ], "Unexpected Node.Outputs[ 0 ]" );
			Assert.AreSame( null, testNode2.Inputs[ 1 ], "Unexpected Node.Inputs[ 1 ]" );
		}
	}
}
