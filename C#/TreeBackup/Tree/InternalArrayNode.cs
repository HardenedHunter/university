﻿using System;
using System.Diagnostics;

// ReSharper disable CommentTypo
// ReSharper disable InvalidXmlDocComment

namespace Tree
{
    //Класс "Внутреннее звено", основа – линейный список
    public class InternalArrayNode<T> : ArrayNode<T> where T : IComparable
    {
        public List<ArrayNode<T>> Children;
        public int Factor { get; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="factor">
        /// Параметр ветвления. Каждый внутренний узел содержит
        /// от (factor - 1) до (factor * 2 - 1) ключей и на один
        /// больше дочерних узлов. Для корня от 1 до (factor * 2 - 1).
        /// </param>
        public InternalArrayNode(int factor)
        {
            Keys = new ArrayList<T>();
            Children = new List<ArrayNode<T>>();
            Factor = factor;
        }

        /// <summary>
        /// Рекурсивное удаление ключа из узла. Внутренние узлы
        /// передают управление листьевым, откуда и производится
        /// удаление. Возможна перестройка структуры дерева из-за
        /// нехватки ключей.
        /// </summary>
        /// <param name="key">Удаляемый ключ</param>
        /// <returns>
        /// Узел дерева, который станет новым корнем, если в текущем корне
        /// не останется ключей.
        /// </returns>
        public override ArrayNode<T> Remove(T key)
        {
            //Выбор потомка, которому нужно передать удаление
            ArrayNode<T> child = GetChild(key);
            child.Remove(key);
            if (child.IsUnderFlow())
            {
                ArrayNode<T> childLeftSibling = GetChildLeftSibling(key);
                ArrayNode<T> childRightSibling = GetChildRightSibling(key);
                if (childRightSibling != null && childRightSibling.Keys.Count >= Factor)
                {
                    T borrowed = childRightSibling.Keys[0];
                    child.Keys.Add(borrowed);
                    childRightSibling.Keys.Remove(borrowed);
                    T newSeparator = childRightSibling.Keys[0];
                    int location = Keys.IndexInSorted(newSeparator);
                    if (location < 0)
                        Keys[-location - 2] = newSeparator;
                }
                else
                {
                    if (childLeftSibling != null && childLeftSibling.Keys.Count >= Factor)
                    {
                        T borrowed = childLeftSibling.Keys[childLeftSibling.Keys.Count - 1];
                        child.Keys.Add(borrowed);
                        childLeftSibling.Keys.Remove(borrowed);
                    }
                    else
                    {
                        ArrayNode<T> left = childLeftSibling ?? child;
                        ArrayNode<T> right = childLeftSibling != null ? child : childRightSibling;
                        left.Merge(right);
                        //right никогда не null
                        if (right.Keys.Count == 0 && Keys.Contains(key))
                        {
                            DeleteChild(key);
                        }
                        else
                        {
                            DeleteChild(right.GetFirstLeafKey());
                        }

                        if (left.IsOverflow())
                        {
                            ArrayNode<T> sibling = left.Split();
                            InsertChild(sibling.GetFirstLeafKey(), sibling);
                        }

                        return left;
                    }
                }
            }

            int updateIndex = Keys.IndexOf(key);
            if (updateIndex >= 0) Keys[updateIndex] = Children[updateIndex + 1].GetFirstLeafKey();
            return null;
        }

        /// <summary>
        /// Рекурсивное добавление ключа в узел. Внутренние узлы
        /// передают управление листьевым, где и производится
        /// добавление. Возможна перестройка структуры дерева из-за
        /// переполнения ключей.
        /// </summary>
        /// <param name="key">Добавляемый ключ.</param>
        public override void Add(T key)
        {
            ArrayNode<T> child = GetChild(key);
            child.Add(key);
            if (child.IsOverflow())
            {
                ArrayNode<T> sibling = child.Split();
                InsertChild(sibling.GetFirstLeafKey(), sibling);
            }
        }

        /// <summary>
        /// Слияние двух узлов.
        /// </summary>
        /// <param name="sibling">Брат, с которым происходит слияние.</param>
        public override void Merge(ArrayNode<T> sibling)
        {
            InternalArrayNode<T> node = (InternalArrayNode<T>)sibling;
            //Спускает Separator сверху
            Keys.Add(node.GetFirstLeafKey());
            Keys.AddRange(node.Keys);
            Children.AddRange(node.Children);
        }

        /// <summary>
        /// Деление узла.
        /// </summary>
        /// <returns>Появившийся в результате деления узел.</returns>
        public override ArrayNode<T> Split()
        {
            int from = Keys.Count / 2 + 1;
            int count = Keys.Count - from;
            InternalArrayNode<T> sibling = new InternalArrayNode<T>(Factor);
            sibling.Keys.AddRange(Keys.GetRange(from, count));
            sibling.Children.AddRange(Children.GetRange(from, count + 1));

            Keys = Keys.GetRange(0, from - 1);
            Children = Children.GetRange(0, from);
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
        /// Возвращает самый левый (т.е. наименьший) ключ,
        /// находящийся на листьевом уровне.
        /// </summary>
        /// <returns>Ключ.</returns>
        public override T GetFirstLeafKey()
        {
            return Children[0].GetFirstLeafKey();
        }

        /// <summary>
        /// Возвращает самый первый (т.е. самый левый) лист в поддереве
        /// </summary>
        /// <returns>Лист дерева.</returns>
        public override LeafArrayNode<T> GetFirstLeaf()
        {
            return Children[0].GetFirstLeaf();
        }

        /// <summary>
        /// По ключу находит потомка, в котором может находиться
        /// переданный ключ. Для подробностей реализации см.
        /// описание метода IndexInSorted в классе List.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Потомок.</returns>
        private ArrayNode<T> GetChild(T key)
        {
            int location = Keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            return Children[childIndex];
        }

        /// <summary>
        /// Аналог GetChild, но возвращающий левого брата того
        /// потомка, где может находиться переданный ключ.
        /// Используется при нехватке ключей, чтобы "одолжить"
        /// ключи у брата, или слить брата и потомка в один узел.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Левый брат потомка, где находится переданный ключ.</returns>
        private ArrayNode<T> GetChildLeftSibling(T key)
        {
            int location = Keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            return childIndex > 0 ? Children[childIndex - 1] : null;
        }

        /// <summary>
        /// Аналог GetChild, но возвращающий правого брата того
        /// потомка, где может находиться переданный ключ.
        /// Используется при нехватке ключей, чтобы "одолжить"
        /// ключи у брата, или слить брата и потомка в один узел.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Правый брат потомка, где находится переданный ключ.</returns>
        private ArrayNode<T> GetChildRightSibling(T key)
        {
            int location = Keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            return childIndex < Keys.Count ? Children[childIndex + 1] : null;
        }

        /// <summary>
        /// Удаление ключа и связанного с ним потомка.
        /// </summary>
        /// <param name="key">Ключ.</param>
        private bool DeleteChild(T key)
        {
            int index = Keys.IndexOf(key);
            bool result = index >= 0;
            if (result)
            {
                Keys.RemoveAt(index);
                Children.RemoveAt(index + 1);
            }

            return result;
        }

        /// <summary>
        /// Добавление ключа и связанного с ним потомка.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <param name="child">Потомок.</param>
        private void InsertChild(T key, ArrayNode<T> child)
        {
            int location = Keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            if (location >= 0)
            {
                Children[childIndex] = child;
            }
            else
            {
                Keys.Insert(childIndex, key);
                Children.Insert(childIndex + 1, child);
            }
        }

        /// <summary>
        /// Сравнение двух узлов, реализация интерфейса IComparable.
        /// Необходимо, чтобы создать List<ArrayNode<T>>, так как в классе List
        /// стоит ограничение на тип Т: IComparable. В самой программе
        /// данный метод не вызывается.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (!(obj is InternalArrayNode<T> otherNode))
                throw new ArgumentException("Object is not a ArrayNode.");
            return Factor.CompareTo(otherNode.Factor);
        }
    }
}