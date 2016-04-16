using System;
using System.Linq;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;
using Matrix = MathNet.Numerics.LinearAlgebra.Double.SparseMatrix;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace DependLib
{
	public class LaplacianMatrix : Matrix
	{

		public LaplacianMatrix (int order)
			: base(order)
		{
		}

		public TokenIndexMap TokenMap { get; } = new TokenIndexMap();

		private Evd<double> Decomposition { get; set; }

		public string this[string depending]
		{
			set 
			{
				if (depending == value) 
				{
					//do nothing because self-dependencies are not useful
					//and they interfere with calculation of degree
					return;
				}
				var row = TokenMap.GetIndex (depending);
				var column = TokenMap.GetIndex (value);

				var adjacencyEntryNotSet = this[row, column].CoerceZero() == 0d;

				if (adjacencyEntryNotSet) 
				{ 
					//increase degree
					this [row, row] = this [row, row].Increment();

					//increment adjacency
					//(inverted to allow use without further processing)
					this[row, column] = this [row, column].Decrement();
				}
				//else do nothing because this is not a multigraph
			}
		}

		public Vector<double> FiedlerVector
		{
			get 
			{
				Decomposition = this.Evd();
				return Decomposition.EigenVectors.Row (1);
			}
		}
	}
}

