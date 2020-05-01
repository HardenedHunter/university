using System;
using System.Diagnostics;
// ReSharper disable CommentTypo
// ReSharper disable InvalidXmlDocComment

namespace Tree
{
    //Класс "Листьевое звено", основа – линейный список
    public class LinkedLeafNode<T> : Node<T> where T : IComparable
    {
        /// <summary>
        /// Указатель на следующий лист (на брата).
        /// </summary>
        public LinkedLeafNode<T> Next;
        /// <summary>
        /// Параметр ветвления (вместимости) узла.
        /// </summary>
        public int Factor { get; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="factor">
        /// Параметр ветвления. Каждый лист содержит
        /// от (factor - 1) до (factor * 2 - 1) ключей.
        /// Для корня от 1 до (factor * 2 - 1).
        /// </param>
        public LinkedLeafNode(int factor)
        {
            Keys = new List<T>();
            Factor = factor;
        }

        /// <summary>
        /// Удаление ключа из листа.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Указатель на себя (для реализации метода из Node).</returns>
        public override Node<T> Remove(T key)
        {
            int location = Keys.IndexInSorted(key);
            if (location >= 0)
            {
                Keys.RemoveAt(location);
            }
            return this;
        }

        /// <summary>
        /// Добавление ключа в звено.
        /// </summary>
        /// <param name="key">Ключ.</param>
        public override void Add(T key)
        {
            int location = Keys.IndexInSorted(key);
            int insertIndex = location >= 0 ? location : -location - 1;
            Keys.Insert(insertIndex, key);
        }

        /// <summary>
        /// Возвращает первый (т.е. наименьший) ключ в листе.
        /// </summary>
        /// <returns>Ключ.</returns>
        public override T GetFirstLeafKey()
        {
            return Keys[0];
         }

        /// <summary>
        /// Слияние двух узлов.
        /// </summary>
        /// <param name="sibling">Брат, с которым происходит слияние.</param>
        public override void Merge(Node<T> sibling)
        {
            LinkedLeafNode<T> node = (LinkedLeafNode<T>) sibling;
            Keys.AddRange(node.Keys);
            Next = node.Next;
        }

        /// <summary>
        /// Деление узла.
        /// </summary>
        /// <returns>Появившийся в результате деления узел.</returns>
        public override Node<T> Split()
        {
            int from = Keys.Count / 2;
            int count = Keys.Count - from;
            LinkedLeafNode<T> sibling = new LinkedLeafNode<T>(Factor);
            sibling.Keys.AddRange(Keys.GetRange(from, count));
            Keys = Keys.GetRange(0, from);
            sibling.Next = Next;
            Next = sibling;
            return sibling;
        }

        /// <summary>
        /// Проверка на переполнение ключей.
        /// </summary>
        /// <returns>Переполнен узел или нет.</returns>
        public override bool IsOverflow()
        {
            return Keys.Count >= Factor * 2;
        }

        /// <summary>
        /// Проверка на нехватку ключей.
        /// </summary>
        /// <returns>Есть нехватка ключей или нет.</returns>
        public override bool IsUnderFlow()
        {
            return Keys.Count < Factor - 1;
        }

        /// <summary>
        /// Сравнение двух узлов, реализация интерфейса IComparable.
        /// Необходимо, чтобы создать List<Node<T>>, так как в классе List
        /// стоит ограничение на тип Т: IComparable. В самой программе
        /// данный метод не вызывается.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (!(obj is LinkedNode<T> otherNode))
                throw new ArgumentException("Object is not a Node");
            return Factor.CompareTo(otherNode.Factor);
        }
    }
}