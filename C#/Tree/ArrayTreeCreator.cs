using System;
// ReSharper disable CommentTypo

namespace Tree
{
    /// <summary>
    /// Класс-создатель для деревьев на основе массива
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayTreeCreator<T> : ITreeCreator<T> where T : IComparable
    {
        public ITree<T> CreateTree(int factor = 2)
        {
            return new ArrayTree<T>(factor);
        }
    }
}