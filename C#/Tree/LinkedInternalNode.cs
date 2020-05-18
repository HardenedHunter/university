using System;
// ReSharper disable CommentTypo

namespace Tree
{
    /// <summary>
    /// Класс "Внутреннее звено на основе линейного списка"
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedInternalNode<T> : InternalNode<T> where T : IComparable
    {    
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="factor">
        /// Параметр ветвления. Каждый внутренний узел содержит
        /// от (factor - 1) до (factor * 2 - 1) ключей и на один
        /// больше дочерних узлов. Для корня от 1 до (factor * 2 - 1).
        /// </param>
        public LinkedInternalNode(int factor)
        {
            Keys = new LinkedCollection<T>();
            Children = new LinkedCollection<TreeNode<T>>();
            Factor = factor;
            Factory = new LinkedNodeFactory<T>();
        }

    }
}