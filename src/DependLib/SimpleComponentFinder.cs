using System;
using System.Linq;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;
using Matrix = MathNet.Numerics.LinearAlgebra.Double.SparseMatrix;
using System.Collections.Generic;

namespace DependLib
{
	public class SimpleComponentFinder
	{

		public int ComponentCount 
		{
			get;
			set;
		}

		const double EPSILON = 0.005d;

		public SimpleComponentFinder (Matrix degree, Matrix adjacency, TokenIndexMap tokens, int clusterCount)
		{
			//var spectralDecomposition = dependencies.Evd ();
			//var smallestEigenvector = spectralDecomposition.EigenVectors.Row (1);
			//ComponentCount = Math.Min (smallestEigenvector.Count, clusterCount);
			var laplacian = degree - adjacency;
			var fiedlerVector = laplacian.Evd().EigenVectors.Row (1);
			clusterCount = (int)Math.Min (fiedlerVector.Count (d => d != 0d) / 3.0d, clusterCount);
			var offset = (fiedlerVector.Minimum() < 0d ? -1.0d * fiedlerVector.Minimum() : 0d);
			var shifted = fiedlerVector.Add (offset);
			var sortedElements = shifted.Select ((e,i) => new KeyValuePair<int,double> (i, e))
				.OrderByDescending (kv => kv.Key).Reverse ().ToList ();
			var breaks = NaturalBreaks ((from kv in sortedElements
					select kv.Value).ToList (), clusterCount);
			var firstGroup = shifted.Where (e => e < breaks.ElementAt (0)).Select ((e, i) => tokens [i]).ToList ();
			var secondGroup = shifted.Where (e => e < breaks.ElementAt (1)).Select ((e, i) => tokens [i]).ToList ();
			var thirdGroup = shifted.Where (e => e > breaks.ElementAt (1)).Select ((e, i) => tokens [i]).ToList ();

		}

		private static List<double> NaturalBreaks(List<double> sListDouble, int sClassCount)
		{
			var pResult = new List<double>();
			for (int i = 0; i < sClassCount; i++)
				pResult.Add(0);

			int numdata = sListDouble.Count;
			sListDouble.Sort();

			double[,] mat1 = new double[numdata + 1, sClassCount + 1];
			double[,] mat2 = new double[numdata + 1, sClassCount + 1];
			for (int i = 1; i <= sClassCount; i++)
			{
				mat1[1, i] = 1;
				mat2[1, i] = 0;
				for (int j = 2; j <= numdata; j++)
				{
					mat2[j, i] = double.MaxValue;
				}
			}

			double ssd = 0;
			for (int rangeEnd = 2; rangeEnd <= numdata; rangeEnd++)
			{
				double sumX = 0;
				double sumX2 = 0;
				double w = 0;
				int dataId;
				for (int m = 1; m <= rangeEnd; m++)
				{
					dataId = rangeEnd - m + 1;
					double val = sListDouble[dataId - 1];
					sumX2 += val * val;
					sumX += val;
					w++;
					ssd = sumX2 - (sumX * sumX) / w;
					for (int j = 2; j <= sClassCount; j++)
					{
						if (!(mat2[rangeEnd, j] < (ssd + mat2[dataId - 1, j - 1])))
						{
							mat1[rangeEnd, j] = dataId;
							mat2[rangeEnd, j] = ssd + mat2[dataId - 1, j - 1];
						}
					}
				}
				mat1[rangeEnd, 1] = 1;
				mat2[rangeEnd, 1] = ssd;
			}

			pResult[sClassCount - 1] = sListDouble[numdata - 1];

			int k = numdata;
			for (int j = sClassCount; j >= 2; j--)
			{
				int id = (int)(mat1[k, j]) - 2;
				pResult[j - 2] = sListDouble[id];
				k = (int)mat1[k, j] - 1;
			}

			return pResult;
		}
	}
}

