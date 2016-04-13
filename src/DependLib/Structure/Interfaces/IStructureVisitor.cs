using System;

namespace DependLib
{
	public interface IStructureVisitor<out M> where M : IDependencyMatrix
	{
		M Visit(IParsedStructure<M> structure);
		M VisitChildNodes(ISourceElement<M> child);
	}
}

