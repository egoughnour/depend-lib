using System;

namespace DependLib
{
	public interface IParsedStructure<out M> where M : IDependencyMatrix
	{
		ISourceElement<M> ChildNodes { get; }
	}
}

