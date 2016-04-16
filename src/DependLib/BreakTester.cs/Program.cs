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
