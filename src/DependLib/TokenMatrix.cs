using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;
using Matrix = MathNet.Numerics.LinearAlgebra.Double.SparseMatrix;

namespace DependLib
{
	public class TokenMatrix: Matrix
	{
		public TokenMatrix(int order)
			: base(order)
		{

		}



		public TokenIndexMap Map { get; } = new TokenIndexMap();

		public int this[string label]
		{
			get
			{
				return Map [label];
			}
			set 
			{
				Map.Insert (value, label);
			}
		}

		public string this[int index]
		{
			get
			{
				return Map [index];
			}

			set 
			{
				Map.Insert (index, value);
			}
		}

		public double this[int row, int column, string label]
		{
			set 
			{
				this [row, column] = value;
				this [row] = label;
			}
		}
	}
}

