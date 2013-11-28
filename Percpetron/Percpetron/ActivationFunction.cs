

namespace Perceptron
{
	public enum ActivationFunction
	{
		Threshold = 1,		// f(x) = ( x < 0 ) ? 0 : 1
		Sigmoid,			// f(x) = 1 / ( e ^ -x + 1 )
		HyperbolicTangent	// f(x) = ( e ^ 2x - 1 ) / ( e ^ 2x + 1 )
	}
}
