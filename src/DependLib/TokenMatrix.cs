using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;
using Matrix = MathNet.Numerics.LinearAlgebra.Double.SparseMatrix;

namespace DependLib
{
	public class TokenMatrix<T> : Matrix where T
	{
		public TokenMatrix(int rows, int columns)
			: base(rows, columns)
		{
		}

		public TokenMatrix(int order)
			: base(order)
		{

		}
	}
}

