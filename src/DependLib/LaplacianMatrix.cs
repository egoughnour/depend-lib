using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;
using Matrix = MathNet.Numerics.LinearAlgebra.Double.SparseMatrix;
using System.Collections.Generic;

namespace DependLib
{
	public class LaplacianMatrix : Matrix
	{

		private Dictionary<string,int> Degree { get; } = new Dictionary<string,int>();

		private Matrix Adjacency { get; }

		public TokenIndexMap Map { get; } = new TokenIndexMap();

		public LaplacianMatrix (int order)
			: base(order)
		{
			Adjacency = new Matrix (order);
		}

		public string this[string depending]
		{
			set 
			{
				var row = Map.GetIndex (depending);
				var column = Map.GetIndex (value);

				var degreeEntryExists = Adjacency.Row (row).AbsoluteMaximum () > 0d;
				var adjacencyEntryNotSet = (!degreeEntryExists)
				                           || (Math.Abs (Adjacency [row, column]) < 0.5d);
				if (adjacencyEntryNotSet) 
				{ 
					if (!degreeEntryExists) 
					{
						Degree [depending] = 0;
					}
					Degree [depending] = Degree[depending] + 1;
					Adjacency [row, column] = 1.0d;
				}
				//else do nothing because this is not a multigraph
			}
		}


	}
}

