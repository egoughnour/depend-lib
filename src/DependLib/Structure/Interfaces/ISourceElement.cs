using System;

namespace DependLib
{
	public interface ISourceElement<out M> : IParsedStructure<M> where M : IDependencyMatrix
	{
		IParsedStructure<M> Root {get;}
		ISourceElement<M> Parent { get;}
		IDependencyNode AsGraphNode{ get; }
	}
}

