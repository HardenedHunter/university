using System;

namespace Tree
{
    public class LinkedTree<T> : Tree<T> where T : IComparable
    {
        public LinkedTree(int factor = DefaultFactor)
        {
            if (factor < MinFactor)
                throw new ArgumentOutOfRangeException();
            Factor = factor;
            Factory = new LinkedNodeFactory<T>();
            Clear();
        }
    }
}