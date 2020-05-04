using System;

namespace Tree
{ 
    public class TreeUtils
    {
        public delegate ITree<T> TreeConstructorDelegate<T>(int factor);

        public delegate bool CheckDelegate<in T>(T node);

        public delegate void ActionDelegate<in T>(T node);

        public static ITree<T> ArrayTreeConstructor<T>(int factor) where T : IComparable
        {
            return new ArrayTree<T>(factor);
        }

        public static ITree<T> LinkedTreeConstructor<T>(int factor) where T: IComparable
        {
            return new LinkedTree<T>(factor);
        }

        public static bool Exists<T>(ITree<T> tree, CheckDelegate<T> check)
        {
            foreach (var element in tree)
            {
                if (check(element))
                    return true;
            }

            return false;
        }

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

        public static void ForEach<T>(ITree<T> tree, ActionDelegate<T> action)
        {
            foreach (var element in tree)
            {
                action(element);
            }
        }

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