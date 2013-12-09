using System;
using ArtificialNeuralNetwork;

namespace MLPIntegration
{
	enum Colour { Black, Red, Green, Blue };

	class Program
	{
		static void Main( string[] args )
		{
			Console.WriteLine( "======================================" );
			Console.WriteLine( "MLP Red-Green-Blue Colour Sorting Test" );
			Console.WriteLine( "======================================" );
			Console.WriteLine();
			Console.WriteLine( "=== Training Data ===" );
			Console.WriteLine();

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

			// Dump the training data set
			foreach ( TrainingSet data in trainingData )
			{
				Console.WriteLine( 
					"DATASET  >>  Input: (" + data.Inputs[ 0 ] + ", " + data.Inputs[ 1 ] + ", " + data.Inputs[ 2 ] + "), " +
					"Output: " + data.Outputs[ 0 ] + ", " + data.Outputs[ 1 ] + ", " + data.Outputs[ 2 ] + ")"
				);
			}

			Console.WriteLine();
			Console.WriteLine( "=== Test Results ===" );
			Console.WriteLine();

			// Set up the MLP and configure its inputs to receive values bounded [0, 255]
			// Note: This is to allow the MLP to normalize inputs to the range [0, 1]
			MLP testMLP = new MLP( 3, 10, 3, ActivationFunction.Threshold );
			testMLP.Inputs[ 0 ].MinValue =   0f;
			testMLP.Inputs[ 0 ].MaxValue = 255f;
			testMLP.Inputs[ 1 ].MinValue =   0f;
			testMLP.Inputs[ 1 ].MaxValue = 255f;
			testMLP.Inputs[ 2 ].MinValue =   0f;
			testMLP.Inputs[ 2 ].MaxValue = 255f;

			// Train the MLP
			testMLP.Train( trainingData, 0.1f, 2f, -0.2f, 0.2f );

			// Test some arbitrary input to verify the trained node can categorize colours correctly
			int repetitions = 1000;
			int correctCount = 0;
			for ( int i = 0; i < repetitions; i++ )
			{
				testMLP.Inputs[ 0 ].Value = (int)Helper.Random( 0f, 255f );
				testMLP.Inputs[ 1 ].Value = (int)Helper.Random( 0f, 255f );
				testMLP.Inputs[ 2 ].Value = (int)Helper.Random( 0f, 255f );
				testMLP.Cycle();

				// Categorize input colour the old-fashioned way
				Colour inputColour = Colour.Black;
				if ( testMLP.Inputs[ 0 ].Value > testMLP.Inputs[ 1 ].Value )
				{
					if ( testMLP.Inputs[ 0 ].Value > testMLP.Inputs[ 2 ].Value )
					{
						// Input colour is red
						inputColour = Colour.Red;
					}
					else
					{
						if ( testMLP.Inputs[ 1 ].Value > testMLP.Inputs[ 2 ].Value )
						{
							// Input colour is green
							inputColour = Colour.Green;
						}
						else
						{
							// Input colour is blue
							inputColour = Colour.Blue;
						}
					}
				}
				else
				{
					if ( testMLP.Inputs[ 1 ].Value > testMLP.Inputs[ 2 ].Value )
					{
						// Input colour is green
						inputColour = Colour.Green;
					}
					else
					{
						if ( testMLP.Inputs[ 2 ].Value > testMLP.Inputs[ 0 ].Value )
						{
							// Input colour is blue
							inputColour = Colour.Blue;
						}
						else
						{
							// Input colour is red
							inputColour = Colour.Red;
						}
					}
				}

				// Categorize the output colour from the values of the output terminals
				Colour outputColour = Colour.Black;
				if ( testMLP.Outputs[ 0 ].Value > 0.9f )
				{
					outputColour = Colour.Red;
				}
				else if ( testMLP.Outputs[ 1 ].Value > 0.9f )
				{
					outputColour = Colour.Green;
				}
				else if ( testMLP.Outputs[ 2 ].Value > 0.9f )
				{
					outputColour = Colour.Blue;
				}

				// Check the answer for correctness
				bool correct = ( inputColour == outputColour );

				Console.WriteLine( 
					( ( correct ) ? "CORRECT" : "WRONG" ) + "  >>  " + 
					"Input: " + inputColour + ", " +
					"Output: " + outputColour + ", " +
					"Input Colour: (" + testMLP.Inputs[ 0 ].Value + ", " + testMLP.Inputs[ 1 ].Value + ", " + testMLP.Inputs[ 2 ].Value + "), " +
					"Output Signals: (" + testMLP.Outputs[ 0 ].Value + ", " + testMLP.Outputs[ 1 ].Value + ", " + testMLP.Outputs[ 2 ].Value + ")"
				);

				if ( correct ) correctCount++;
			}

			float percentCorrect = 100f * (float)correctCount / (float)repetitions;
			Console.WriteLine();
			Console.WriteLine( percentCorrect + "% ( " + correctCount + " / " + repetitions + " )" );
			Console.WriteLine();
			Console.WriteLine( "Training Step: " + testMLP.TrainingStep );
			Console.WriteLine( "Training Epochs: " + testMLP.TrainingEpochs );
			Console.WriteLine( "Training MSE: " + testMLP.TrainingMeanSquaredError );

			Console.ReadKey();
		}
	}
}
