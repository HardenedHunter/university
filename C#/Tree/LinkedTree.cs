using System;
// ReSharper disable CommentTypo

namespace Tree
{
    /// <summary>
    /// Класс Б+ дерева на основе линейного списка
    /// </summary>
    /// <typeparam name="T"></typeparam>
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