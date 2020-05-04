using System;

namespace Tree
{
    public class ArrayTree<T> : Tree<T> where T : IComparable
    {
        public ArrayTree(int factor = DefaultFactor)
        {
            if (factor < MinFactor)
                throw new ArgumentOutOfRangeException();
            Factor = factor;
            Factory = new ArrayNodeFactory<T>();
            Clear();
        }
    }
}