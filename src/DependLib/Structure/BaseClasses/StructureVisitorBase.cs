using System;

namespace DependLib
{
	public abstract class StructureVisitorBase : IStructureVisitor<AbstractDependencyMatrix>
	{

		#region IStructureVisitor implementation

		public AbstractDependencyMatrix Visit (IParsedStructure<AbstractDependencyMatrix> structure)
		{
			throw new NotImplementedException ();
		}

		public AbstractDependencyMatrix VisitChildNodes (ISourceElement<AbstractDependencyMatrix> child)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

