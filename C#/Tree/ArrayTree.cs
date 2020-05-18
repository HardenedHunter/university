using System;
// ReSharper disable CommentTypo

namespace Tree
{
    /// <summary>
    /// Класс Б+ дерева на основе массива
    /// </summary>
    /// <typeparam name="T"></typeparam>
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