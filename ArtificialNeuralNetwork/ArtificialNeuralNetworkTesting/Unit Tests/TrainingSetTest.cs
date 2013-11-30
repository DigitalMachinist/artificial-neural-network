using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtificialNeuralNetwork;

namespace ArtificialNeuralNetworkTesting
{
	[TestClass]
	public class TrainingSetTest
	{
		/// <summary>
		/// Init() configures the training set correctly taking whole arrays as input.
		/// </summary>
		[TestMethod]
		public void TrainingSetInitArrayMode()
		{
			TrainingSet testTrainingSet = new TrainingSet();
			testTrainingSet.Init( new float[] { 1f, 2f, 3f, 4f, 5f }, new float[] { 1f, 2f, 3f } );
			Assert.AreEqual( 1f, testTrainingSet.Inputs[ 0 ], 0.001, "Unexpected TrainingSet.Inputs[ 0 ]" );
			Assert.AreEqual( 2f, testTrainingSet.Inputs[ 1 ], 0.001, "Unexpected TrainingSet.Inputs[ 1 ]" );
			Assert.AreEqual( 3f, testTrainingSet.Inputs[ 2 ], 0.001, "Unexpected TrainingSet.Inputs[ 2 ]" );
			Assert.AreEqual( 4f, testTrainingSet.Inputs[ 3 ], 0.001, "Unexpected TrainingSet.Inputs[ 3 ]" );
			Assert.AreEqual( 5f, testTrainingSet.Inputs[ 4 ], 0.001, "Unexpected TrainingSet.Inputs[ 4 ]" );
			Assert.AreEqual( 1f, testTrainingSet.Outputs[ 0 ], 0.001, "Unexpected TrainingSet.Outputs[ 0 ]" );
			Assert.AreEqual( 2f, testTrainingSet.Outputs[ 1 ], 0.001, "Unexpected TrainingSet.Outputs[ 1 ]" );
			Assert.AreEqual( 3f, testTrainingSet.Outputs[ 2 ], 0.001, "Unexpected TrainingSet.Outputs[ 2 ]" );
		}
		
		/// <summary>
		/// Init() configures the training set correctly when building arrays of given size.
		/// </summary>
		[TestMethod]
		public void TrainingSetInitSizeMode()
		{
			TrainingSet testTrainingSet = new TrainingSet();
			testTrainingSet.Init( 5, 3 );
			Assert.AreNotSame( null, testTrainingSet.Inputs, "Input array was unexpectedly null" );
			Assert.AreEqual( 5, testTrainingSet.Inputs.Length, "Unexpected input array length" );
			Assert.AreNotSame( null, testTrainingSet.Outputs, "Output array was unexpectedly null" );
			Assert.AreEqual( 3, testTrainingSet.Outputs.Length, "Unexpected output array length" );
		}

		/// <summary>
		/// Init() throws an ArgumentOutOfRangeException for a numInputs value of 0 or less.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void TrainingSetInitNumInputsOutOfRange()
		{
			TrainingSet testTrainingSet = new TrainingSet();
			testTrainingSet.Init( -1, 3 );
		}

		/// <summary>
		/// Init() throws an ArgumentOutOfRangeException for a numOutputs value of 0 or less.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void TrainingSetInitNumOutputsOutOfRange()
		{
			TrainingSet testTrainingSet = new TrainingSet();
			testTrainingSet.Init( 5, -1 );
		}
		
		/// <summary>
		/// Init() configures the training set correctly taking whole arrays as input.
		/// </summary>
		[TestMethod]
		public void TrainingSetConstructor2ArgsArrayMode()
		{
			TrainingSet testTrainingSet = new TrainingSet( new float[] { 1f, 2f, 3f, 4f, 5f }, new float[] { 1f, 2f, 3f } );
			Assert.AreEqual( 1f, testTrainingSet.Inputs[ 0 ], 0.001, "Unexpected TrainingSet.Inputs[ 0 ]" );
			Assert.AreEqual( 2f, testTrainingSet.Inputs[ 1 ], 0.001, "Unexpected TrainingSet.Inputs[ 1 ]" );
			Assert.AreEqual( 3f, testTrainingSet.Inputs[ 2 ], 0.001, "Unexpected TrainingSet.Inputs[ 2 ]" );
			Assert.AreEqual( 4f, testTrainingSet.Inputs[ 3 ], 0.001, "Unexpected TrainingSet.Inputs[ 3 ]" );
			Assert.AreEqual( 5f, testTrainingSet.Inputs[ 4 ], 0.001, "Unexpected TrainingSet.Inputs[ 4 ]" );
			Assert.AreEqual( 1f, testTrainingSet.Outputs[ 0 ], 0.001, "Unexpected TrainingSet.Outputs[ 0 ]" );
			Assert.AreEqual( 2f, testTrainingSet.Outputs[ 1 ], 0.001, "Unexpected TrainingSet.Outputs[ 1 ]" );
			Assert.AreEqual( 3f, testTrainingSet.Outputs[ 2 ], 0.001, "Unexpected TrainingSet.Outputs[ 2 ]" );
		}
		
		/// <summary>
		/// 2-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void TrainingSetConstructor2ArgsSizeMode()
		{
			TrainingSet testTrainingSet = new TrainingSet( 5, 3 );
			Assert.AreNotSame( null, testTrainingSet.Inputs, "Input array was unexpectedly null" );
			Assert.AreEqual( 5, testTrainingSet.Inputs.Length, "Unexpected input array length" );
			Assert.AreNotSame( null, testTrainingSet.Outputs, "Output array was unexpectedly null" );
			Assert.AreEqual( 3, testTrainingSet.Outputs.Length, "Unexpected output array length" );
		}

		/// <summary>
		/// 2-Arg constructor instantiation throws an ArgumentOutOfRangeException for a numOutputs value of 0 or less.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void TrainingSetConstructor2ArgsNumInputsOutOfRange()
		{
			TrainingSet testTrainingSet = new TrainingSet( -1, 3 );
		}

		/// <summary>
		/// 2-Arg constructor instantiation throws an ArgumentOutOfRangeException for a numOutputs value of 0 or less.
		/// </summary>
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void TrainingSetConstructor2ArgsNumOutputsOutOfRange()
		{
			TrainingSet testTrainingSet = new TrainingSet( 5, -1 );
		}

		/// <summary>
		/// 0-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void TrainingSetConstructor0ArgsInRange()
		{
			TrainingSet testTrainingSet = new TrainingSet();
			Assert.AreSame( null, testTrainingSet.Inputs, "Input array was unexpectedly null" );
			Assert.AreSame( null, testTrainingSet.Outputs, "Output array was unexpectedly null" );
		}

		/// <summary>
		/// Inputs getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void TrainingSetGetInputs()
		{
			TrainingSet testTrainingSet = new TrainingSet( 5, 3 );
			Assert.AreNotSame( null, testTrainingSet.Inputs, "Input array was unexpectedly null" );
			Assert.AreEqual( 5, testTrainingSet.Inputs.Length, "Unexpected input array length" );
		}

		/// <summary>
		/// Outputs getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void TrainingSetGetOutputs()
		{
			TrainingSet testTrainingSet = new TrainingSet( 5, 3 );
			Assert.AreNotSame( null, testTrainingSet.Outputs, "Output array was unexpectedly null" );
			Assert.AreEqual( 3, testTrainingSet.Outputs.Length, "Unexpected output array length" );
		}

		/// <summary>
		/// Inputs getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void TrainingSetSetInputs()
		{
			TrainingSet testTrainingSet = new TrainingSet( 5, 3 );
			Assert.AreNotSame( null, testTrainingSet.Inputs, "Input array was unexpectedly null" );
			testTrainingSet.Inputs = new float[] { 1f, 2f, 3f, 4f, 5f };
			Assert.AreEqual( 1f, testTrainingSet.Inputs[ 0 ], 0.001, "Unexpected TrainingSet.Inputs[ 0 ]" );
			Assert.AreEqual( 2f, testTrainingSet.Inputs[ 1 ], 0.001, "Unexpected TrainingSet.Inputs[ 1 ]" );
			Assert.AreEqual( 3f, testTrainingSet.Inputs[ 2 ], 0.001, "Unexpected TrainingSet.Inputs[ 2 ]" );
			Assert.AreEqual( 4f, testTrainingSet.Inputs[ 3 ], 0.001, "Unexpected TrainingSet.Inputs[ 3 ]" );
			Assert.AreEqual( 5f, testTrainingSet.Inputs[ 4 ], 0.001, "Unexpected TrainingSet.Inputs[ 4 ]" );
		}

		/// <summary>
		/// Outputs getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void TrainingSetSetOutputs()
		{
			TrainingSet testTrainingSet = new TrainingSet( 5, 3 );
			testTrainingSet.Outputs = new float[] { 1f, 2f, 3f };
			Assert.AreEqual( 1f, testTrainingSet.Outputs[ 0 ], 0.001, "Unexpected TrainingSet.Outputs[ 0 ]" );
			Assert.AreEqual( 2f, testTrainingSet.Outputs[ 1 ], 0.001, "Unexpected TrainingSet.Outputs[ 1 ]" );
			Assert.AreEqual( 3f, testTrainingSet.Outputs[ 2 ], 0.001, "Unexpected TrainingSet.Outputs[ 2 ]" );
		}
	}
}
