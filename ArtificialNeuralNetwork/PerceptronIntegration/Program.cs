using System;
using ArtificialNeuralNetwork;

namespace PerceptronIntegration
{
	class Program
	{
		static void Main( string[] args )
		{
			Console.WriteLine( "=======================================" );
			Console.WriteLine( "Perceptron Red-Blue Colour Sorting Test" );
			Console.WriteLine( "=======================================" );
			Console.WriteLine();
			Console.WriteLine( "=== Training Data ===" );
			Console.WriteLine();

			// Set up a sufficent set of training data for the perceptron
			// Note: This data is a set of colours in RGB format, bounded [0, 255]. The perceptron
			// is to be trained to output -1f for colours that are more RED, and output 1f for
			// colours that are more BLUE.
			float RED = 0f;
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

			// Dump the training data set
			foreach ( TrainingSet data in trainingData )
			{
				Console.WriteLine( 
					"DATASET  >>  Input: (" + data.Inputs[ 0 ] + ", " + data.Inputs[ 1 ] + ", " + data.Inputs[ 2 ] + "), " +
					"Output: " + ( ( data.Outputs[ 0 ] == BLUE ) ? "BLUE" : "RED" )
				);
			}

			Console.WriteLine();
			Console.WriteLine( "=== Test Results ===" );
			Console.WriteLine();

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
			testPerceptron.Train( trainingData, 0.1f, 0.1f, -0.2f, 0.2f );
			
			// Test some arbitrary input to verify the trained node can categorize colours correctly
			int repetitions = 1000;
			int correctCount = 0;
			for ( int i = 0; i < repetitions; i++ )
			{
				testPerceptron.Inputs[ 0 ].Value = (int)Helper.Random( 0f, 255f );
				testPerceptron.Inputs[ 1 ].Value = (int)Helper.Random( 0f, 255f );
				testPerceptron.Inputs[ 2 ].Value = (int)Helper.Random( 0f, 255f );
				testPerceptron.Cycle();

				bool isRed		= ( testPerceptron.Inputs[ 0 ].Value > testPerceptron.Inputs[ 2 ].Value );
				bool guessedRed = ( testPerceptron.Output.Value < 0.5f );
				bool correct	= ( isRed == guessedRed );

				Console.WriteLine( 
					( ( correct ) ? "CORRECT" : "WRONG" ) + "  >>  " + 
					"Output: " + testPerceptron.Output.Value + ", " +
					"Colour: (" + testPerceptron.Inputs[ 0 ].Value + ", " + testPerceptron.Inputs[ 1 ].Value + ", " + testPerceptron.Inputs[ 2 ].Value + ")"
				);

				if ( correct ) correctCount++;
			}

			float percentCorrect = 100f * (float)correctCount / (float)repetitions;
			Console.WriteLine();
			Console.WriteLine( percentCorrect + "% ( " + correctCount + " / " + repetitions + " )" );
			Console.WriteLine();
			Console.WriteLine( "Training Epochs: " + testPerceptron.TrainingEpochs );
			Console.WriteLine( "Training MSE: " + testPerceptron.TrainingMeanSquaredError );

			Console.ReadKey();
		}
	}
}
