using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;
using Matrix = MathNet.Numerics.LinearAlgebra.Double.SparseMatrix;

namespace DependLib
{
	public class SimpleComponentFinder
	{

		public int ComponentCount 
		{
			get;
			set;
		}

		public SimpleComponentFinder (Matrix dependencies, TokenIndexMap tokens, int clusterCount)
		{
			var spectralDecomposition = dependencies.Evd ();
			var smallestEigenvector = spectralDecomposition.EigenVectors.Row (1);
			ComponentCount = Math.Min (smallestEigenvector.Count, clusterCount);

		}
	}
}

