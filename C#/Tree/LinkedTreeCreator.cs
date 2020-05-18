using System;
// ReSharper disable CommentTypo

namespace Tree
{
    /// <summary>
    /// Класс-создатель для деревьев на основе линейного списка
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedTreeCreator<T>: ITreeCreator<T> where T : IComparable
    {
        public ITree<T> CreateTree(int factor = 2)
        {
            return new LinkedTree<T>(factor);
        }
    }
}