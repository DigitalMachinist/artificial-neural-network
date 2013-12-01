using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtificialNeuralNetwork;

namespace ArtificialNeuralNetworkTesting
{
	[TestClass]
	public class PerceptronTest
	{
		/// <summary>
		/// Init() configures the perceptron correctly.
		/// </summary>
		[TestMethod]
		public void PerceptronInit()
		{
			Perceptron testPerceptron = new Perceptron();
			testPerceptron.Init( 2, ActivationFunction.HyperbolicTangent );
			Assert.AreNotSame( null, testPerceptron.Node, "Perceptron.Node unexpectedly null" );
			Assert.AreNotSame( null, testPerceptron.Inputs, "Perceptron.Inputs unexpectedly null" );
			Assert.AreEqual( 0f, testPerceptron.Inputs[ 0 ].Value, "Unexpected Perceptron.Inputs[ 0 ].Value" );
			Assert.AreEqual( 0f, testPerceptron.Inputs[ 1 ].Value, "Unexpected Perceptron.Inputs[ 1 ].Value" );
			Assert.AreNotSame( null, testPerceptron.Output, "Perceptron.Output unexpectedly null" );
			Assert.AreEqual( 0f, testPerceptron.Output.Value, "Unexpected Perceptron.Output.Value" );
			Assert.AreEqual( true, testPerceptron.IsReady, "Unexpected Perceptron.IsReady" );
		}

		/// <summary>
		/// Init() throws ArgumentOutOfRangeException for out-of-range numInputs.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void PerceptronInitNumInputsOutOfRange()
		{
			Perceptron testPerceptron = new Perceptron();
			testPerceptron.Init( 0, ActivationFunction.HyperbolicTangent );
		}

		/// <summary>
		/// 2-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void PerceptronConstructor2Arg()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.HyperbolicTangent );
			Assert.AreNotSame( null, testPerceptron.Node, "Perceptron.Node unexpectedly null" );
			Assert.AreNotSame( null, testPerceptron.Inputs, "Perceptron.Inputs unexpectedly null" );
			Assert.AreEqual( 0f, testPerceptron.Inputs[ 0 ].Value, "Unexpected Perceptron.Inputs[ 0 ].Value" );
			Assert.AreEqual( 0f, testPerceptron.Inputs[ 1 ].Value, "Unexpected Perceptron.Inputs[ 1 ].Value" );
			Assert.AreNotSame( null, testPerceptron.Output, "Perceptron.Output unexpectedly null" );
			Assert.AreEqual( 0f, testPerceptron.Output.Value, "Unexpected Perceptron.Output.Value" );
			Assert.AreEqual( true, testPerceptron.IsReady, "Unexpected Perceptron.IsReady" );
		}

		/// <summary>
		/// 2-Arg constructor instantiation throws ArgumentOutOfRangeException for out-of-range numInputs.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void PerceptronConstructor2ArgNumInputsOutOfRange()
		{
			Perceptron testPerceptron = new Perceptron( 0, ActivationFunction.HyperbolicTangent );
		}

		/// <summary>
		/// 0-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void PerceptronConstructor0Arg()
		{
			Perceptron testPerceptron = new Perceptron();
			Assert.AreSame( null, testPerceptron.Node, "Perceptron.Node unexpectedly null" );
			Assert.AreSame( null, testPerceptron.Inputs, "Perceptron.Inputs unexpectedly null" );
			Assert.AreSame( null, testPerceptron.Output, "Perceptron.Output unexpectedly null" );
			Assert.AreEqual( false, testPerceptron.IsReady, "Unexpected Perceptron.IsReady" );
		}

		/// <summary>
		/// Cycle() correctly configures the weights of the inputs given a set of training data.
		/// </summary>
		[TestMethod]
		public void PerceptronTrain()
		{
			// Set up a sufficent set of training data for the perceptron
			// Note: This data is a set of colours in RGB format, bounded [0, 255]. The perceptron
			// is to be trained to output -1f for colours that are more RED, and output 1f for
			// colours that are more BLUE.
			float RED  = 0f;
			float BLUE = 1f;
			TrainingSet[] trainingData = new TrainingSet[] {
				new TrainingSet( new float[] {	  0,	  0,	255	}, new float[] { BLUE } ),
				new TrainingSet( new float[] {	  0,	  0,	192	}, new float[] { BLUE } ),
				new TrainingSet( new float[] {	243,	 80,	 59	}, new float[] { RED  } ),
				new TrainingSet( new float[] {	255,	  0,	 77	}, new float[] { RED  } ),
				new TrainingSet( new float[] {	 77,	 93,	190	}, new float[] { BLUE } ),
				new TrainingSet( new float[] {	255,	 98,	 89	}, new float[] { RED  } ),
				new TrainingSet( new float[] {	208,	  0,	 49	}, new float[] { RED  } ),
				new TrainingSet( new float[] {	 67,	 15,	210	}, new float[] { BLUE } ),
				new TrainingSet( new float[] {	 82,	117,	174	}, new float[] { BLUE } ),
				new TrainingSet( new float[] {	168,	 42,	 89	}, new float[] { RED  } ),
				new TrainingSet( new float[] {	248,	 80,	 68	}, new float[] { RED  } ),
				new TrainingSet( new float[] {	128,	 80,	255	}, new float[] { BLUE } ),
				new TrainingSet( new float[] {	228,	105,	116	}, new float[] { RED  } )
			};

			// Set up the perceptron and configure its inputs to receive values bounded [0, 255]
			// Note: This is to allow the perceptron to normalize inputs to the range [0, 1]
			Perceptron testPerceptron = new Perceptron( 3, ActivationFunction.Threshold );
			testPerceptron.Inputs[ 0 ].MinValue =   0f;
			testPerceptron.Inputs[ 0 ].MaxValue = 255f;
			testPerceptron.Inputs[ 1 ].MinValue =   0f;
			testPerceptron.Inputs[ 1 ].MaxValue = 255f;
			testPerceptron.Inputs[ 2 ].MinValue =   0f;
			testPerceptron.Inputs[ 2 ].MaxValue = 255f;

			// Train the perceptron
			testPerceptron.Train( trainingData, 0.1f, 0.1f, 0.5f, 0.5f );

			// Test the weights of the inputs after training
			// TODO How do I predict this in advance by some independent means?
			// For now I'm just going to put this code into Cycle() and if the system categorizes
			// colours correctly I'll say that's good enough.
			Assert.Fail( "EXPECTED FAILURE (Test not implemented yet)" );
		}

		/// <summary>
		/// Train() throws a NotReadyException if called when IsReady = false.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArtificialNeuralNetwork.NotReadyException ) )]
		public void PerceptronTrainNotReady()
		{
			Perceptron testPerceptron = new Perceptron();
			TrainingSet[] testTrainingData = { new TrainingSet( 2, 1 ) };
			testPerceptron.Train( testTrainingData, 1f, 1f, -0.5f, 0.5f );
		}

		/// <summary>
		/// Cycle() correctly sets the outputs of the perceptron given a set of input values and weights.
		/// </summary>
		[TestMethod]
		public void PerceptronCycle()
		{
			// Set up a sufficent set of training data for the perceptron
			// Note: This data is a set of colours in RGB format, bounded [0, 255]. The perceptron
			// is to be trained to output -1f for colours that are more RED, and output 1f for
			// colours that are more BLUE.
			float RED  = 0f;
			float BLUE = 1f;
			TrainingSet[] trainingData = new TrainingSet[] {
				new TrainingSet( new float[] {	  0,	  0,	255	}, new float[] { BLUE } ),
				new TrainingSet( new float[] {	  0,	  0,	192	}, new float[] { BLUE } ),
				new TrainingSet( new float[] {	243,	 80,	 59	}, new float[] { RED  } ),
				new TrainingSet( new float[] {	255,	  0,	 77	}, new float[] { RED  } ),
				new TrainingSet( new float[] {	 77,	 93,	190	}, new float[] { BLUE } ),
				new TrainingSet( new float[] {	255,	 98,	 89	}, new float[] { RED  } ),
				new TrainingSet( new float[] {	208,	  0,	 49	}, new float[] { RED  } ),
				new TrainingSet( new float[] {	 67,	 15,	210	}, new float[] { BLUE } ),
				new TrainingSet( new float[] {	 82,	117,	174	}, new float[] { BLUE } ),
				new TrainingSet( new float[] {	168,	 42,	 89	}, new float[] { RED  } ),
				new TrainingSet( new float[] {	248,	 80,	 68	}, new float[] { RED  } ),
				new TrainingSet( new float[] {	128,	 80,	255	}, new float[] { BLUE } ),
				new TrainingSet( new float[] {	228,	105,	116	}, new float[] { RED  } )
			};

			// Set up the perceptron and configure its inputs to receive values bounded [0, 255]
			// Note: This is to allow the perceptron to normalize inputs to the range [0, 1]
			Perceptron testPerceptron = new Perceptron( 3, ActivationFunction.Threshold );
			testPerceptron.Inputs[ 0 ].MinValue =   0f;
			testPerceptron.Inputs[ 0 ].MaxValue = 255f;
			testPerceptron.Inputs[ 1 ].MinValue =   0f;
			testPerceptron.Inputs[ 1 ].MaxValue = 255f;
			testPerceptron.Inputs[ 2 ].MinValue =   0f;
			testPerceptron.Inputs[ 2 ].MaxValue = 255f;

			// Train the perceptron
			testPerceptron.Train( trainingData, 0.1f, 0.1f, 0.5f, 0.5f );

			// Test some arbitrary input to verify the trained node can categorize colours correctly
			// Prefect Red (255, 0, 0)
			testPerceptron.Inputs[ 0 ].Value = 255;
			testPerceptron.Inputs[ 1 ].Value =   0;
			testPerceptron.Inputs[ 2 ].Value =   0;
			testPerceptron.Cycle();
			Assert.AreEqual( RED, testPerceptron.Output.Value, 0.001, "Unexpected Perceptron.Output.Value" );
			// Perfect Blue (255, 0, 0)
			testPerceptron.Inputs[ 0 ].Value =   0;
			testPerceptron.Inputs[ 1 ].Value =   0;
			testPerceptron.Inputs[ 2 ].Value = 255;
			testPerceptron.Cycle();
			Assert.AreEqual( BLUE, testPerceptron.Output.Value, 0.001, "Unexpected Perceptron.Output.Value" );
			//// Violet (101, 20, 165)
			//testPerceptron.Inputs[ 0 ].Value = 101;
			//testPerceptron.Inputs[ 1 ].Value =  20;
			//testPerceptron.Inputs[ 2 ].Value = 165;
			//testPerceptron.Cycle();
			//Assert.AreEqual( BLUE, testPerceptron.Output.Value, 0.001, "Unexpected Perceptron.Output.Value" );
			//// Leaf Green (80, 220, 45)
			//testPerceptron.Inputs[ 0 ].Value =  80;
			//testPerceptron.Inputs[ 1 ].Value = 220;
			//testPerceptron.Inputs[ 2 ].Value =  45;
			//testPerceptron.Cycle();
			//Assert.AreEqual( RED, testPerceptron.Output.Value, 0.001, "Unexpected Perceptron.Output.Value" );
		}

		/// <summary>
		/// Cycle() throws a NotReadyException if called when IsReady = false.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArtificialNeuralNetwork.NotReadyException ) )]
		public void PerceptronCycleNotReady()
		{
			Perceptron testPerceptron = new Perceptron();
			testPerceptron.Cycle();
		}

		/// <summary>
		/// CopyTrainingSetToInputs() correctly sets the input values from the training set inputs.
		/// </summary>
		[TestMethod]
		public void PerceptronCopyTrainingSetToInputs()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.Sigmoid );
			TrainingSet testTrainingSet = new TrainingSet( 2, 1 );
			testTrainingSet.Inputs[ 0 ] = 0.50f;
			testTrainingSet.Inputs[ 1 ] = 0.25f;
			testPerceptron.CopyTrainingSetToInputs( testTrainingSet );
			Assert.AreEqual( 0.50f, testPerceptron.Inputs[ 0 ].Value, 0.001, "Unexpected Perceptron.Inputs[ 0 ].Value" );
			Assert.AreEqual( 0.25f, testPerceptron.Inputs[ 1 ].Value, 0.001, "Unexpected Perceptron.Inputs[ 1 ].Value" );
		}

		/// <summary>
		/// CopyTrainingSetToInputs() throws an ArgumentException if the number of inputs in the training set differ
		/// the number of inputs in the perceptron.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void PerceptronCopyTrainingSetToInputsDataSetMisfit()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.Sigmoid );
			TrainingSet testTrainingSet = new TrainingSet( 1, 1 );
			testPerceptron.CopyTrainingSetToInputs( testTrainingSet );
		}

		/// <summary>
		/// AdjustNodeWeights() correctly adjusts the weights of the inputs based on the amount of error at output.
		/// </summary>
		[TestMethod]
		public void PerceptronAdjustNodeWeights()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.Sigmoid );
			testPerceptron.Node.Inputs[ 0 ].Value  = 0.1f;
			testPerceptron.Node.Inputs[ 0 ].Weight = 0.7f;
			testPerceptron.Node.Inputs[ 1 ].Value  = 0.3f;
			testPerceptron.Node.Inputs[ 1 ].Weight = 0.5f;
			testPerceptron.AdjustNodeWeights( -2f, 0.1f );
			Assert.AreEqual( 0.68f, testPerceptron.Node.Inputs[ 0 ].Weight, 0.001, "Unexpected Perceptron.Node.Inputs[ 0 ].Weight" );
			Assert.AreEqual( 0.44f, testPerceptron.Node.Inputs[ 1 ].Weight, 0.001, "Unexpected Perceptron.Node.Inputs[ 1 ].Weight" );
		}

		/// <summary>
		/// CopyInputsToNodeValues() correctly sets the node's input values from the inputs.
		/// </summary>
		[TestMethod]
		public void PerceptronCopyInputsToNodeValues()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.Sigmoid );
			testPerceptron.Inputs[ 0 ].Value = 0.50f;
			testPerceptron.Inputs[ 1 ].Value = 0.25f;
			testPerceptron.CopyInputsToNodeValues();
			Assert.AreEqual( 0.50f, testPerceptron.Node.Inputs[ 0 ].Value, 0.001, "Unexpected Perceptron.Node.Inputs[ 0 ].Value" );
			Assert.AreEqual( 0.25f, testPerceptron.Node.Inputs[ 1 ].Value, 0.001, "Unexpected Perceptron.Node.Inputs[ 1 ].Value" );
		}

		/// <summary>
		/// CopyNodeValueToOutput() correctly sets the output from the node's output value.
		/// </summary>
		[TestMethod]
		public void PerceptronCopyNodeValueToOutput()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.Sigmoid );
			testPerceptron.Node.Outputs[ 0 ].Value = 0.75f;
			testPerceptron.CopyNodeValueToOutput();
			Assert.AreEqual( 0.75f, testPerceptron.Output.Value, 0.001, "Unexpected Perceptron.Output.Value" );
		}

		/// <summary>
		/// Inputs getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void PerceptronGetInputs()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.Sigmoid );
			Assert.AreNotSame( null, testPerceptron.Inputs, "Unexpected Perceptron.Inputs" );
			Assert.AreEqual( 2, testPerceptron.Inputs.Length, "Unexpected Perceptron.Inputs.Length" );
		}

		/// <summary>
		/// Output getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void PerceptronGetOutput()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.Sigmoid );
			Assert.AreNotSame( null, testPerceptron.Output, "Unexpected Perceptron.Output" );
		}

		/// <summary>
		/// Node getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void PerceptronGetNode()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.Sigmoid );
			Assert.AreNotSame( null, testPerceptron.Node, "Unexpected Perceptron.Node" );
		}

		/// <summary>
		/// TrainingEpochs getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void PerceptronGetTrainingEpochs()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.Sigmoid );
			Assert.AreNotSame( 0, testPerceptron.TrainingEpochs, "Unexpected Perceptron.TrainingEpochs" );
		}

		/// <summary>
		/// TrainingMeanSquaredError getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void PerceptronGetTrainingMeanSquaredError()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.Sigmoid );
			Assert.AreEqual( 0, testPerceptron.TrainingMeanSquaredError, "Unexpected Perceptron.TrainingMeanSquaredError" );
		}

		/// <summary>
		/// TrainingStep getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void PerceptronGetTrainingStep()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.Sigmoid );
			Assert.AreEqual( 0f, testPerceptron.TrainingStep, 0.001, "Unexpected Perceptron.TrainingStep" );
		}

		/// <summary>
		/// IsReady getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void PerceptronGetIsReady()
		{
			Perceptron testPerceptron = new Perceptron( 2, ActivationFunction.Sigmoid );
			Assert.AreEqual( true, testPerceptron.IsReady, "Unexpected Perceptron.IsReady" );
		}
	}
}
