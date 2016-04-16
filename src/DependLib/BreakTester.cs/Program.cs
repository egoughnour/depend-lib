using System;
using DependLib;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;

namespace BreakTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var degree = new TokenMatrix (6);
			var adjacency = new SparseMatrix (6);

			degree [0, 0, "A"] = 2.0d;
			degree [1, 1, "B"] = 3.0d;
			degree [2, 2, "C"] = 2.0d;
			degree [3, 3, "D"] = 3.0d;
			degree [4, 4, "E"] = 3.0d;
			degree [5, 5, "F"] = 1.0d;

			adjacency [0, 1] = 1.0d;
			adjacency [0, 4] = 1.0d;

			adjacency [1, 0] = 1.0d;
			adjacency [1, 2] = 1.0d;
			adjacency [1, 4] = 1.0d;

			adjacency [2, 1] = 1.0d;
			adjacency [2, 3] = 1.0d;

			adjacency [3, 2] = 1.0d;
			adjacency [3, 4] = 1.0d;
			adjacency [3, 5] = 1.0d;

			adjacency [4, 0] = 1.0d;
			adjacency [4, 1] = 1.0d;
			adjacency [4, 3] = 1.0d;

			adjacency [5, 3] = 1.0d;


			var componentFinder = new SimpleComponentFinder (degree, adjacency, degree.Map, 3);

			var L = new LaplacianMatrix (6);

			L ["A"] = "B";
			L ["A"] = "E";

			L ["B"] = "A";
			L ["B"] = "C";
			L ["B"] = "E";

			L ["C"] = "B";
			L ["C"] = "D";

			L ["D"] = "C";
			L ["D"] = "E";
			L ["D"] = "F";

			L ["E"] = "A";
			L ["E"] = "B";
			L ["E"] = "D";

			L ["F"] = "E";

			var streamlined = new SimpleComponentFinder (L, 3);

			streamlined.CalculateComponents ();

			foreach (var component in streamlined.Components) 
			{
				Console.WriteLine ("-------Component---------");
				Console.WriteLine ("Contained Nodes: " + string.Join (", ", component.Nodes));
				Console.WriteLine ();
			}
		}
	}
}
