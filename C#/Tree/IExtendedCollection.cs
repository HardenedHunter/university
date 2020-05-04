using System;
using System.Collections.Generic;

namespace Tree
{
    public interface IExtendedCollection<T> : IList<T>, IEnumerator<T> where T : IComparable
    {
        int IndexInSorted(T item);
        void AddRange(IEnumerable<T> collection);
        IExtendedCollection<T> GetRange(int index, int count);
    }
}