using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtificialNeuralNetwork;

namespace ArtificialNeuralNetworkTesting
{
	[TestClass]
	public class MLPTest
	{
		/// <summary>
		/// Init() configures the MLP correctly.
		/// </summary>
		[TestMethod]
		public void MLPInit()
		{
			MLP testMLP = new MLP();
			testMLP.Init( 3, 2, 1, ActivationFunction.Sigmoid );
			Assert.AreNotSame( null, testMLP.InputLayer, "MLP.InputLayer unexpectedly null" );
			Assert.AreEqual( 3, testMLP.InputLayer.Length, "Unexpected MLP.InputLayer.Length" );
			Assert.AreNotSame( null, testMLP.HiddenLayer, "MLP.InputLayer unexpectedly null" );
			Assert.AreEqual( 2, testMLP.HiddenLayer.Length, "Unexpected MLP.HiddenLayer.Length" );
			Assert.AreNotSame( null, testMLP.OutputLayer, "MLP.InputLayer unexpectedly null" );
			Assert.AreEqual( 1, testMLP.OutputLayer.Length, "Unexpected MLP.OutputLayer.Length" );
			Assert.AreNotSame( null, testMLP.Inputs, "MLP.Inputs unexpectedly null" );
			Assert.AreEqual( 0f, testMLP.Inputs[ 0 ].Value, "Unexpected MLP.Inputs[ 0 ].Value" );
			Assert.AreEqual( 0f, testMLP.Inputs[ 1 ].Value, "Unexpected MLP.Inputs[ 1 ].Value" );
			Assert.AreEqual( 0f, testMLP.Inputs[ 2 ].Value, "Unexpected MLP.Inputs[ 2 ].Value" );
			Assert.AreNotSame( null, testMLP.Outputs, "MLP.Output unexpectedly null" );
			Assert.AreEqual( 0f, testMLP.Outputs[ 0 ].Value, "Unexpected MLP.Outputs[ 0 ].Value" );
			Assert.AreEqual( true, testMLP.IsReady, "Unexpected MLP.IsReady" );
		}

		/// <summary>
		/// Init() throws ArgumentOutOfRangeException for out-of-range numInputLayer.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void MLPInitOutOfRangeNumInputLayer()
		{
			MLP testMLP = new MLP();
			testMLP.Init( -1, 2, 1, ActivationFunction.Sigmoid );
		}

		/// <summary>
		/// Init() throws ArgumentOutOfRangeException for out-of-range numHiddenLayer.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void MLPInitOutOfRangeNumHiddenLayer()
		{
			MLP testMLP = new MLP();
			testMLP.Init( 3, -1, 1, ActivationFunction.Sigmoid );
		}

		/// <summary>
		/// Init() throws ArgumentOutOfRangeException for out-of-range numOutputLayer.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void MLPInitOutOfRangeNumOutputLayer()
		{
			MLP testMLP = new MLP();
			testMLP.Init( 3, 2, -1, ActivationFunction.Sigmoid );
		}

		/// <summary>
		/// 4-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void MLPConstructor4Args()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			Assert.AreNotSame( null, testMLP.InputLayer, "MLP.InputLayer unexpectedly null" );
			Assert.AreEqual( 3, testMLP.InputLayer.Length, "Unexpected MLP.InputLayer.Length" );
			Assert.AreNotSame( null, testMLP.HiddenLayer, "MLP.InputLayer unexpectedly null" );
			Assert.AreEqual( 2, testMLP.HiddenLayer.Length, "Unexpected MLP.HiddenLayer.Length" );
			Assert.AreNotSame( null, testMLP.OutputLayer, "MLP.InputLayer unexpectedly null" );
			Assert.AreEqual( 1, testMLP.OutputLayer.Length, "Unexpected MLP.OutputLayer.Length" );
			Assert.AreNotSame( null, testMLP.Inputs, "MLP.Inputs unexpectedly null" );
			Assert.AreEqual( 0f, testMLP.Inputs[ 0 ].Value, "Unexpected MLP.Inputs[ 0 ].Value" );
			Assert.AreEqual( 0f, testMLP.Inputs[ 1 ].Value, "Unexpected MLP.Inputs[ 1 ].Value" );
			Assert.AreEqual( 0f, testMLP.Inputs[ 2 ].Value, "Unexpected MLP.Inputs[ 2 ].Value" );
			Assert.AreNotSame( null, testMLP.Outputs, "MLP.Output unexpectedly null" );
			Assert.AreEqual( 0f, testMLP.Outputs[ 0 ].Value, "Unexpected MLP.Outputs[ 0 ].Value" );
			Assert.AreEqual( true, testMLP.IsReady, "Unexpected MLP.IsReady" );
		}

		/// <summary>
		/// 4-Arg constructor instantiation throws ArgumentOutOfRangeException for out-of-range numInputLayer.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void MLPConstructor4ArgsOutOfRangeNumInputLayer()
		{
			MLP testMLP = new MLP( -1, 2, 1, ActivationFunction.Sigmoid );
		}

		/// <summary>
		/// 4-Arg constructor instantiation throws ArgumentOutOfRangeException for out-of-range numHiddenLayer.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void MLPConstructor4ArgsOutOfRangeNumHiddenLayer()
		{
			MLP testMLP = new MLP( 3, -1, 1, ActivationFunction.Sigmoid );
		}

		/// <summary>
		/// 4-Arg constructor instantiation throws ArgumentOutOfRangeException for out-of-range numOutputLayer.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void MLPConstructor4ArgsOutOfRangeNumOutputLayer()
		{
			MLP testMLP = new MLP( 3, 2, -1, ActivationFunction.Sigmoid );
		}

		/// <summary>
		/// 0-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void MLPConstructor0Args()
		{
			MLP testMLP = new MLP();
			Assert.AreSame( null, testMLP.InputLayer, "MLP.InputLayer unexpectedly non-null" );
			Assert.AreSame( null, testMLP.HiddenLayer, "MLP.HiddenLayer unexpectedly non-null" );
			Assert.AreSame( null, testMLP.OutputLayer, "MLP.OutputLayer unexpectedly non-null" );
			Assert.AreSame( null, testMLP.Inputs, "MLP.Inputs unexpectedly non-null" );
			Assert.AreSame( null, testMLP.Outputs, "MLP.Outputs unexpectedly non-null" );
			Assert.AreEqual( false, testMLP.IsReady, "Unexpected MLP.IsReady" );
		}

		/// <summary>
		/// Train() correctly configures the weights of the inputs given a set of training data.
		/// </summary>
		[TestMethod]
		public void MLPTrain()
		{
			// Set up a sufficent set of training data for the perceptron
			// Note: This data is a set of colours in RGB format, bounded [0, 255]. The perceptron
			// is to be trained to output -1f for colours that are more RED, and output 1f for
			// colours that are more BLUE.
			float[] RED   = new float[] { 1, 0, 0 };
			float[] GREEN = new float[] { 0, 1, 0 };
			float[] BLUE  = new float[] { 0, 0, 1 };
			TrainingSet[] trainingData = new TrainingSet[] {
				new TrainingSet( new float[] {	  0,	  0,	255	}, BLUE  ),
				new TrainingSet( new float[] {	  0,	  0,	192	}, BLUE  ),
				new TrainingSet( new float[] {	  0,	200,	  0	}, GREEN ),
				new TrainingSet( new float[] {	243,	 80,	 59	}, RED   ),
				new TrainingSet( new float[] {	255,	  0,	 77	}, RED   ),
				new TrainingSet( new float[] {	 86,	140,	 45	}, GREEN ),
				new TrainingSet( new float[] {	 77,	 93,	190	}, BLUE  ),
				new TrainingSet( new float[] {	255,	 98,	 89	}, RED   ),
				new TrainingSet( new float[] {	120,	165,	 96	}, GREEN ),
				new TrainingSet( new float[] {	208,	  0,	 49	}, RED   ),
				new TrainingSet( new float[] {	 67,	 15,	210	}, BLUE  ),
				new TrainingSet( new float[] {	134,	243,	210	}, GREEN ),
				new TrainingSet( new float[] {	 82,	117,	174	}, BLUE  ),
				new TrainingSet( new float[] {	168,	 42,	 89	}, RED   ),
				new TrainingSet( new float[] {	  0,	 43,	  0	}, GREEN ),
				new TrainingSet( new float[] {	248,	 80,	 68	}, RED   ),
				new TrainingSet( new float[] {	128,	 80,	255	}, BLUE  ),
				new TrainingSet( new float[] {	 34,	 75,	 50	}, GREEN ),
				new TrainingSet( new float[] {	228,	105,	116	}, RED   )
			};

			// Set up the MLP and configure its inputs to receive values bounded [0, 255]
			// Note: This is to allow the MLP to normalize inputs to the range [0, 1]
			MLP testMLP = new MLP( 3, 3, 3, ActivationFunction.Threshold );
			testMLP.Inputs[ 0 ].MinValue =   0f;
			testMLP.Inputs[ 0 ].MaxValue = 255f;
			testMLP.Inputs[ 1 ].MinValue =   0f;
			testMLP.Inputs[ 1 ].MaxValue = 255f;
			testMLP.Inputs[ 2 ].MinValue =   0f;
			testMLP.Inputs[ 2 ].MaxValue = 255f;

			// Train the MLP
			testMLP.Train( trainingData, 0.1f, 0.1f, 0.5f, 0.5f );

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
		public void MLPTrainNotReady()
		{
			MLP testMLP = new MLP();
			TrainingSet[] testTrainingData = { new TrainingSet( 2, 1 ) };
			testMLP.Train( testTrainingData, 1f, 1f, -0.5f, 0.5f );
		}

		/// <summary>
		/// TrainHiddenLayer() correctly configures the weights of the input layer neurons 
		/// given that the hidden layer has already been trained based on a set of training data.
		/// </summary>
		[TestMethod]
		public void MLPTrainHiddenLayer()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			testMLP.HiddenLayer[ 0 ].Outputs[ 0 ].Value  = 0.8f; // 1, 2, 3
			testMLP.HiddenLayer[ 0 ].Outputs[ 0 ].Error  = 0.8f;
			testMLP.HiddenLayer[ 0 ].Inputs [ 0 ].Value  = 0.0f; // 1
			testMLP.HiddenLayer[ 0 ].Inputs [ 0 ].Weight = 0.5f;
			testMLP.HiddenLayer[ 0 ].Inputs [ 1 ].Value  = 0.2f; // 2
			testMLP.HiddenLayer[ 0 ].Inputs [ 1 ].Weight = 0.5f;
			testMLP.HiddenLayer[ 0 ].Inputs [ 2 ].Value  = 0.4f; // 3
			testMLP.HiddenLayer[ 0 ].Inputs [ 2 ].Weight = 0.5f;
			testMLP.HiddenLayer[ 1 ].Outputs[ 0 ].Value  = 0.4f; // 4, 5, 6
			testMLP.HiddenLayer[ 1 ].Outputs[ 0 ].Error  = 0.4f;
			testMLP.HiddenLayer[ 1 ].Inputs [ 0 ].Value  = 0.6f; // 4
			testMLP.HiddenLayer[ 1 ].Inputs [ 0 ].Weight = 0.5f;
			testMLP.HiddenLayer[ 1 ].Inputs [ 1 ].Value  = 0.8f; // 5
			testMLP.HiddenLayer[ 1 ].Inputs [ 1 ].Weight = 0.5f;
			testMLP.HiddenLayer[ 1 ].Inputs [ 2 ].Value  = 1.0f; // 6
			testMLP.HiddenLayer[ 1 ].Inputs [ 2 ].Weight = 0.5f;
			testMLP.TrainHiddenLayer( 1f );
			Assert.AreEqual( 0.5000f, testMLP.HiddenLayer[ 0 ].Inputs[ 0 ].Weight, 0.001, "Unexpected MLP.HiddenLayer[ 0 ].Inputs[ 0 ].Weight" );
			Assert.AreEqual( 0.5256f, testMLP.HiddenLayer[ 0 ].Inputs[ 1 ].Weight, 0.001, "Unexpected MLP.HiddenLayer[ 0 ].Inputs[ 1 ].Weight" );
			Assert.AreEqual( 0.5512f, testMLP.HiddenLayer[ 0 ].Inputs[ 2 ].Weight, 0.001, "Unexpected MLP.HiddenLayer[ 0 ].Inputs[ 2 ].Weight" );
			Assert.AreEqual( 0.5576f, testMLP.HiddenLayer[ 1 ].Inputs[ 0 ].Weight, 0.001, "Unexpected MLP.HiddenLayer[ 1 ].Inputs[ 0 ].Weight" );
			Assert.AreEqual( 0.5768f, testMLP.HiddenLayer[ 1 ].Inputs[ 1 ].Weight, 0.001, "Unexpected MLP.HiddenLayer[ 1 ].Inputs[ 1 ].Weight" );
			Assert.AreEqual( 0.5960f, testMLP.HiddenLayer[ 1 ].Inputs[ 2 ].Weight, 0.001, "Unexpected MLP.HiddenLayer[ 1 ].Inputs[ 2 ].Weight" );
		}

		/// <summary>
		/// TrainOutputLayer() correctly configures the weights of the hidden layer neurons 
		/// given a set of training data.
		/// </summary>
		[TestMethod]
		public void MLPTrainOutputLayer()
		{
			MLP testMLP = new MLP( 3, 2, 2, ActivationFunction.Sigmoid );
			testMLP.OutputLayer[ 0 ].Outputs[ 0 ].Value  = 0.8f; // 1, 2
			testMLP.OutputLayer[ 0 ].Inputs [ 0 ].Value  = 0.2f; // 1
			testMLP.OutputLayer[ 0 ].Inputs [ 0 ].Weight = 0.5f;
			testMLP.OutputLayer[ 0 ].Inputs [ 1 ].Value  = 0.4f; // 2
			testMLP.OutputLayer[ 0 ].Inputs [ 1 ].Weight = 0.5f;
			testMLP.OutputLayer[ 1 ].Outputs[ 0 ].Value  = 0.2f; // 3, 4
			testMLP.OutputLayer[ 1 ].Inputs [ 0 ].Value  = 0.6f; // 3
			testMLP.OutputLayer[ 1 ].Inputs [ 0 ].Weight = 0.5f;
			testMLP.OutputLayer[ 1 ].Inputs [ 1 ].Value  = 0.8f; // 4
			testMLP.OutputLayer[ 1 ].Inputs [ 1 ].Weight = 0.5f;
			TrainingSet data = new TrainingSet( new float[] { 0f, 0f, 0f }, new float[] { 0.5f, 0.5f } );
			testMLP.TrainOutputLayer( data, 1f );
			Assert.AreEqual( 0.4904f, testMLP.OutputLayer[ 0 ].Inputs[ 0 ].Weight, 0.001, "Unexpected MLP.OutputLayer[ 0 ].Inputs[ 0 ].Weight" );
			Assert.AreEqual( 0.4804f, testMLP.OutputLayer[ 0 ].Inputs[ 1 ].Weight, 0.001, "Unexpected MLP.OutputLayer[ 0 ].Inputs[ 1 ].Weight" );
			Assert.AreEqual( 0.5288f, testMLP.OutputLayer[ 1 ].Inputs[ 0 ].Weight, 0.001, "Unexpected MLP.OutputLayer[ 0 ].Inputs[ 0 ].Weight" );
			Assert.AreEqual( 0.5384f, testMLP.OutputLayer[ 1 ].Inputs[ 1 ].Weight, 0.001, "Unexpected MLP.OutputLayer[ 0 ].Inputs[ 1 ].Weight" );
		}

		/// <summary>
		/// Cycle() correctly sets the outputs of the MLP given a set of input values and weights.
		/// </summary>
		[TestMethod]
		public void MLPCycle()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );

			testMLP.Cycle();

			Assert.Fail( "EXPECTED FAILURE (Test not implemented yet)" );
			Assert.Fail( "EXPECTED FAILURE (Intermittant behaviour expected)" );
		}

		/// <summary>
		/// CycleInputLayer() correctly sets the outputs of the input layer neurons given a set of 
		/// input values and weights.
		/// </summary>
		[TestMethod]
		public void MLPCycleInputLayer()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Threshold );
			testMLP.InputLayer[ 0 ].Inputs[ 0 ].Value  =  0.500f; // 1
			testMLP.InputLayer[ 0 ].Inputs[ 0 ].Weight =  1.000f;
			testMLP.InputLayer[ 1 ].Inputs[ 0 ].Value  =  0.250f; // 2
			testMLP.InputLayer[ 1 ].Inputs[ 0 ].Weight =  1.000f;
			testMLP.InputLayer[ 2 ].Inputs[ 0 ].Value  =  0.125f; // 3
			testMLP.InputLayer[ 2 ].Inputs[ 0 ].Weight = -1.000f;
			testMLP.CycleInputLayer();
			Assert.AreEqual( 1f, testMLP.HiddenLayer[ 0 ].Inputs[ 0 ].Value, 0.001, "Unexpected MLP.HiddenLayer[ 0 ].Inputs[ 0 ].Value" );
			Assert.AreEqual( 1f, testMLP.HiddenLayer[ 0 ].Inputs[ 1 ].Value, 0.001, "Unexpected MLP.HiddenLayer[ 0 ].Inputs[ 1 ].Value" );
			Assert.AreEqual( 0f, testMLP.HiddenLayer[ 0 ].Inputs[ 2 ].Value, 0.001, "Unexpected MLP.HiddenLayer[ 0 ].Inputs[ 2 ].Value" );
			Assert.AreEqual( 1f, testMLP.HiddenLayer[ 1 ].Inputs[ 0 ].Value, 0.001, "Unexpected MLP.HiddenLayer[ 1 ].Inputs[ 0 ].Value" );
			Assert.AreEqual( 1f, testMLP.HiddenLayer[ 1 ].Inputs[ 1 ].Value, 0.001, "Unexpected MLP.HiddenLayer[ 1 ].Inputs[ 1 ].Value" );
			Assert.AreEqual( 0f, testMLP.HiddenLayer[ 1 ].Inputs[ 2 ].Value, 0.001, "Unexpected MLP.HiddenLayer[ 1 ].Inputs[ 2 ].Value" );
		}

		/// <summary>
		/// CycleHiddenLayer() correctly sets the outputs of the hidden layer neurons given a set of 
		/// input values and weights.
		/// </summary>
		[TestMethod]
		public void MLPCycleHiddenLayer()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Threshold );
			testMLP.HiddenLayer[ 0 ].Inputs[ 0 ].Value  =  0.500f; // 1
			testMLP.HiddenLayer[ 0 ].Inputs[ 0 ].Weight =  1.000f;
			testMLP.HiddenLayer[ 0 ].Inputs[ 1 ].Value  =  0.000f;
			testMLP.HiddenLayer[ 0 ].Inputs[ 1 ].Weight =  1.000f;
			testMLP.HiddenLayer[ 0 ].Inputs[ 2 ].Value  =  0.000f;
			testMLP.HiddenLayer[ 0 ].Inputs[ 2 ].Weight =  1.000f;
			testMLP.HiddenLayer[ 1 ].Inputs[ 0 ].Value  =  0.250f; // 2
			testMLP.HiddenLayer[ 1 ].Inputs[ 0 ].Weight = -1.000f;
			testMLP.HiddenLayer[ 1 ].Inputs[ 1 ].Value  =  0.000f;
			testMLP.HiddenLayer[ 1 ].Inputs[ 1 ].Weight =  1.000f;
			testMLP.HiddenLayer[ 1 ].Inputs[ 2 ].Value  =  0.000f;
			testMLP.HiddenLayer[ 1 ].Inputs[ 2 ].Weight =  1.000f;
			testMLP.CycleHiddenLayer();
			Assert.AreEqual( 1f, testMLP.OutputLayer[ 0 ].Inputs[ 0 ].Value, 0.001, "Unexpected MLP.OutputLayer[ 0 ].Inputs[ 0 ].Value" );
			Assert.AreEqual( 0f, testMLP.OutputLayer[ 0 ].Inputs[ 1 ].Value, 0.001, "Unexpected MLP.OutputLayer[ 0 ].Inputs[ 1 ].Value" );
		}

		/// <summary>
		/// CycleOutputLayer() correctly sets the outputs of the output layer neurons given a set of 
		/// input values and weights.
		/// </summary>
		[TestMethod]
		public void MLPCycleOutputLayer()
		{
			MLP testMLP = new MLP( 3, 2, 2, ActivationFunction.Threshold );
			testMLP.OutputLayer[ 0 ].Inputs[ 0 ].Value  =  0.500f; // 1
			testMLP.OutputLayer[ 0 ].Inputs[ 0 ].Weight =  1.000f;
			testMLP.OutputLayer[ 0 ].Inputs[ 1 ].Value  =  0.000f;
			testMLP.OutputLayer[ 0 ].Inputs[ 1 ].Weight =  1.000f;
			testMLP.OutputLayer[ 1 ].Inputs[ 0 ].Value  =  0.500f; // 2
			testMLP.OutputLayer[ 1 ].Inputs[ 0 ].Weight = -1.000f;
			testMLP.OutputLayer[ 1 ].Inputs[ 1 ].Value  =  0.000f;
			testMLP.OutputLayer[ 1 ].Inputs[ 1 ].Weight =  1.000f;
			testMLP.CycleOutputLayer();
			Assert.AreEqual( 1f, testMLP.OutputLayer[ 0 ].Outputs[ 0 ].Value, 0.001, "Unexpected MLP.OutputLayer[ 0 ].Outputs[ 0 ].Value" );
			Assert.AreEqual( 0f, testMLP.OutputLayer[ 1 ].Outputs[ 0 ].Value, 0.001, "Unexpected MLP.OutputLayer[ 1 ].Outputs[ 0 ].Value" );
		}

		/// <summary>
		/// CopyTrainingSetToInputs() correctly sets the input values from the training set inputs.
		/// </summary>
		[TestMethod]
		public void MLPCopyTrainingSetToInputs()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			TrainingSet data = new TrainingSet( new float[] { 0.500f, 0.250f, 0.125f }, new float[] { 1f } );
			testMLP.CopyTrainingSetToInputs( data );
			Assert.AreEqual( 0.500f, testMLP.Inputs[ 0 ].Value, 0.001, "Unexpected MLP.InputLayer[ 0 ].Inputs[ 0 ].Value" );
			Assert.AreEqual( 0.250f, testMLP.Inputs[ 1 ].Value, 0.001, "Unexpected MLP.InputLayer[ 1 ].Inputs[ 0 ].Value" );
			Assert.AreEqual( 0.125f, testMLP.Inputs[ 2 ].Value, 0.001, "Unexpected MLP.InputLayer[ 2 ].Inputs[ 0 ].Value" );
		}

		/// <summary>
		/// CopyInputsToInputLayer() correctly sets the input layer neuron values from the inputs.
		/// </summary>
		[TestMethod]
		public void MLPCopyInputsToInputLayer()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			testMLP.Inputs[ 0 ].Value = 0.500f;
			testMLP.Inputs[ 1 ].Value = 0.250f;
			testMLP.Inputs[ 2 ].Value = 0.125f;
			testMLP.CopyInputsToInputLayer();
			Assert.AreEqual( 0.500f, testMLP.InputLayer[ 0 ].Inputs[ 0 ].Value, 0.001, "Unexpected MLP.InputLayer[ 0 ].Inputs[ 0 ].Value" );
			Assert.AreEqual( 0.250f, testMLP.InputLayer[ 1 ].Inputs[ 0 ].Value, 0.001, "Unexpected MLP.InputLayer[ 1 ].Inputs[ 0 ].Value" );
			Assert.AreEqual( 0.125f, testMLP.InputLayer[ 2 ].Inputs[ 0 ].Value, 0.001, "Unexpected MLP.InputLayer[ 2 ].Inputs[ 0 ].Value" );
		}

		/// <summary>
		/// CopyOutputLayerToOutputs() correctly sets the outputs from the output layer neuron values.
		/// </summary>
		[TestMethod]
		public void MLPCopyOutputLayerToOutputs()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			testMLP.OutputLayer[ 0 ].Outputs[ 0 ].Value = 0.500f;
			testMLP.CopyOutputLayerToOutputs();
			Assert.AreEqual( 0.500f, testMLP.OutputLayer[ 0 ].Outputs[ 0 ].Value, 0.001, "Unexpected MLP.OutputLayer[ 0 ].Outputs[ 0 ].Value" );
		}

		/// <summary>
		/// Inputs getter property returns correctly.
		/// </summary>
		public void MLPGetInputs()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			Assert.AreNotSame( null, testMLP.Inputs, "Unexpected MLP.Inputs" );
			Assert.AreEqual( 3, testMLP.Inputs.Length, "Unexpected MLP.Inputs.Length" );
		}

		/// <summary>
		/// Output getter property returns correctly.
		/// </summary>
		public void MLPGetOutputs()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			Assert.AreNotSame( null, testMLP.Outputs, "Unexpected MLP.Outputs" );
			Assert.AreEqual( 1, testMLP.Outputs.Length, "Unexpected MLP.Outputs.Length" );
		}

		/// <summary>
		/// InputLayer getter property returns correctly.
		/// </summary>
		public void MLPGetInputLayer()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			Assert.AreNotSame( null, testMLP.InputLayer, "Unexpected MLP.InputLayer" );
			Assert.AreEqual( 3, testMLP.InputLayer.Length, "Unexpected MLP.InputLayer.Length" );
		}

		/// <summary>
		/// HiddenLayer getter property returns correctly.
		/// </summary>
		public void MLPGetHiddenLayer()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			Assert.AreNotSame( null, testMLP.HiddenLayer, "Unexpected MLP.HiddenLayer" );
			Assert.AreEqual( 2, testMLP.HiddenLayer.Length, "Unexpected MLP.HiddenLayer.Length" );
		}

		/// <summary>
		/// OutputLayer getter property returns correctly.
		/// </summary>
		public void MLPGetOutputLayer()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			Assert.AreNotSame( null, testMLP.OutputLayer, "Unexpected MLP.OutputLayer" );
			Assert.AreEqual( 1, testMLP.OutputLayer.Length, "Unexpected MLP.OutputLayer.Length" );
		}

		/// <summary>
		/// TrainingEpochs getter property returns correctly.
		/// </summary>
		public void MLPGetTrainingEpochs()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			Assert.AreEqual( 0, testMLP.TrainingEpochs, "Unexpected MLP.TrainingEpochs" );
		}

		/// <summary>
		/// TrainingMeanSquaredError getter property returns correctly.
		/// </summary>
		public void MLPGetTrainingMeanSquaredError()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			Assert.AreEqual( 0f, testMLP.TrainingMeanSquaredError, 0.001, "Unexpected MLP.TrainingMeanSquaredError" );
		}

		/// <summary>
		/// TrainingStep getter property returns correctly.
		/// </summary>
		public void MLPGetTrainingStep()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			Assert.AreEqual( 0f, testMLP.TrainingStep, 0.001, "Unexpected MLP.TrainingStep" );
		}

		/// <summary>
		/// IsReady getter property returns correctly.
		/// </summary>
		public void MLPGetIsReady()
		{
			MLP testMLP = new MLP( 3, 2, 1, ActivationFunction.Sigmoid );
			Assert.AreEqual( true, testMLP.IsReady, "Unexpected MLP.IsReady" );
		}
	}
}
