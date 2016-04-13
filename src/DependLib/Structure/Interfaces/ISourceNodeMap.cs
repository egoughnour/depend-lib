using System;

namespace DependLib
{
	public interface ISourceNodeMap<T,U,V> where U : ISourceElement<T> where V : IDependencyNode 
	{
		bool ContainsEquivalentElement(U elementToFind);
		V this [U indexValue] {
			get;
			set;
		}
		U this [V indexKey] {
			get;
			set;
		}
	}
}

