using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Perceptron;

namespace PerceptronTesting
{
	[TestClass]
	public class TrainingSetTest
	{
		/// <summary>
		/// 2-Arg constructor instantiation sets variables correctly.
		/// </summary>
		[TestMethod]
		public void Constructor2Args()
		{
			TrainingSet testTrainingSet = new TrainingSet( 5, 3 );
			Assert.AreNotSame( null, testTrainingSet.AppliedInputs, "Input array was unexpectedly null" );
			Assert.AreEqual( 5, testTrainingSet.AppliedInputs.Length, "Unexpected input array length" );
			Assert.AreNotSame( null, testTrainingSet.TargetOutputs, "Output array was unexpectedly null" );
			Assert.AreEqual( 3, testTrainingSet.TargetOutputs.Length, "Unexpected output array length" );
		}

		/// <summary>
		/// AppliedInputs getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void GetAppliedInputs()
		{
			TrainingSet testTrainingSet = new TrainingSet( 5, 3 );
			Assert.AreNotSame( null, testTrainingSet.AppliedInputs, "Input array was unexpectedly null" );
			Assert.AreEqual( 5, testTrainingSet.AppliedInputs.Length, "Unexpected input array length" );
		}

		/// <summary>
		/// TargetOutputs getter property returns correctly.
		/// </summary>
		[TestMethod]
		public void GetTargetOutputs()
		{
			TrainingSet testTrainingSet = new TrainingSet( 5, 3 );
			Assert.AreNotSame( null, testTrainingSet.TargetOutputs, "Output array was unexpectedly null" );
			Assert.AreEqual( 3, testTrainingSet.TargetOutputs.Length, "Unexpected output array length" );
		}
	}
}
