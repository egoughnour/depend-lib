using System;
using System.Linq;
using System.Collections.Generic;

namespace DependLib
{
	public class Component
	{

		public List<string> Nodes { get; private set;}

		public Component (LaplacianMatrix L, List<KeyValuePair<int,double>> sortedEigenvectorComponents, double cutoffValue = double.MaxValue)
		{
			Nodes = sortedEigenvectorComponents.Where (e => e.Value < cutoffValue).Select (e => L.TokenMap[e.Key]).ToList ();
		}

		public void CullUsedNodes(List<string> usedNodes)
		{
			Nodes.RemoveAll (usedNodes.Contains);
		}
	}
}

