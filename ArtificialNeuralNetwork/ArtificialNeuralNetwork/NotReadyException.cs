using System;

namespace ArtificialNeuralNetwork
{
	public class NotReadyException : Exception
	{
		public NotReadyException( string message, Exception innerException ) : base( message, innerException )
		{
			
		}
		public NotReadyException( string message ) : base( message )
		{
			
		}
		public NotReadyException() : base()
		{
			
		}
	}
}
