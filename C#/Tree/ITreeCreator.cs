using System;

namespace Tree
{
    /// <summary>
    /// Интерфейс создателя Б+ деревьев
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITreeCreator<T> where T : IComparable
    {
        ITree<T> CreateTree(int factor = 2);
    }
}