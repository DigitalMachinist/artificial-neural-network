using System;

namespace Perceptron
{
	public class MLP
	{
		#region Member Variables
		

		private Node[] __hiddenLayer;
		private Node[] __inputLayer;
		private Node[] __outputLayer;

		#endregion

		#region Initialization



		#endregion

		#region Methods

		public void ConnectNodes( Node inputNode, int inputIndex, Node outputNode, int outputIndex )
		{
			Terminal t = new Terminal( inputNode, outputNode );
			inputNode.Outputs[ inputIndex ] = t;
			outputNode.Inputs[ outputIndex ] = t;
		}

		public void DisconnectNodes( Node inputNode, int inputIndex, Node outputNode, int outputIndex )
		{
			inputNode.Outputs[ inputIndex ] = null;
			outputNode.Inputs[ outputIndex ] = null;
		}

		#endregion

		#region Properties



		#endregion
	}
}
