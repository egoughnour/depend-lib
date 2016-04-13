using System;

namespace DependLib
{ 
	public abstract class AbstractSourceElement : ISourceElement<AbstractDependencyMatrix>
	{
		IParsedStructure<AbstractDependencyMatrix> ISourceElement<AbstractDependencyMatrix>.Root {
			get {
				throw new NotImplementedException ();
			}
		}

		ISourceElement<AbstractDependencyMatrix> ISourceElement<AbstractDependencyMatrix>.Parent {
			get {
				throw new NotImplementedException ();
			}
		}

		ISourceElement<AbstractDependencyMatrix> IParsedStructure<AbstractDependencyMatrix>.ChildNodes {
			get {
				throw new NotImplementedException ();
			}
		}

		#region ISourceElement implementation 
		AbstractParsedStructure Root {
			get {
				throw new NotImplementedException ();
			}
		} AbstractSourceElement Parent {
			get {
				throw new NotImplementedException ();
			}
		}
		public IDependencyNode AsGraphNode {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
		#region IParsedStructure implementation 
		AbstractSourceElement ChildNodes {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
	}
}

