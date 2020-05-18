using System;
// ReSharper disable CommentTypo

namespace Tree
{ 
    /// <summary>
    /// Класс операций над деревом
    /// </summary>
    public class TreeUtils
    {
        public delegate ITree<T> TreeConstructorDelegate<T>(int factor);

        public delegate bool CheckDelegate<in T>(T node);

        public delegate void ActionDelegate<in T>(T node);

        /// <summary>
        /// Проверка на существование элемента
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree">Дерево</param>
        /// <param name="check">Делегат проверки</param>
        /// <returns></returns>
        public static bool Exists<T>(ITree<T> tree, CheckDelegate<T> check)
        {
            foreach (var element in tree)
            {
                if (check(element))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Поиск всех элементов, удовлетворяющих условию
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree">Дерево</param>
        /// <param name="check">Делегат проверки</param>
        /// <param name="constructor">Делегат построения дерева-результата</param>
        /// <returns></returns>
        public static ITree<T> FindAll<T>(ITree<T> tree, CheckDelegate<T> check, TreeConstructorDelegate<T> constructor)
        {
            var resultTree = constructor(tree.Factor);
            foreach (var element in tree)
            {
                if (check(element))
                    resultTree.Add(element);
            }

            return resultTree;
        }

        /// <summary>
        /// Выполнение заданного делегата для каждого элемента дерева
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree">Дерево</param>
        /// <param name="action">Делегат действия</param>
        public static void ForEach<T>(ITree<T> tree, ActionDelegate<T> action)
        {
            foreach (var element in tree)
            {
                action(element);
            }
        }

        /// <summary>
        /// Проверка на выполнение условия для всех элементов дерева
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree">Дерево</param>
        /// <param name="check">Делегат проверки</param>
        /// <returns></returns>
        public static bool CheckForAll<T>(ITree<T> tree, CheckDelegate<T> check)
        {
            foreach (var element in tree)
            {
                if (!check(element))
                    return false;
            }

            return true;
        }
    }
}