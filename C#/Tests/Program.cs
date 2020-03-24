using System;
using System.ComponentModel.Design;
using Tree;

namespace Tests
{
    class Program
    {
        static void PrintWrapper(Node<int> node)
        {
            PrintTree(node);
            Console.WriteLine();
        }

        static void PrintTree(Node<int> node)
        {
            node.Keys.Print();
            if (node is LinkedNode<int> tmp)
                foreach (var tmpChild in tmp.Children)
                {
                    PrintTree(tmpChild);
                }
        }

        static void Main(string[] args)
        {
            var tree =  new LinkedTree<int>(2);
            tree.Add(1);
            PrintWrapper(tree._root);
            tree.Add(2);
            PrintWrapper(tree._root);
            tree.Add(3);
            PrintWrapper(tree._root);
            tree.Add(4);
            PrintWrapper(tree._root);
            tree.Add(5);
            PrintWrapper(tree._root);
            tree.Add(6);
            PrintWrapper(tree._root);
            tree.Add(7);
            PrintWrapper(tree._root);
            tree.Add(8);
            PrintWrapper(tree._root);
            tree.Add(9);
            PrintWrapper(tree._root);
            tree.Add(10);
            PrintWrapper(tree._root);

            tree.Remove(1);
            PrintWrapper(tree._root);
            tree.Remove(2);
            PrintWrapper(tree._root);
            tree.Remove(5);
            PrintWrapper(tree._root);
            tree.Remove(6);
            PrintWrapper(tree._root);
            tree.Remove(3);
            PrintWrapper(tree._root);
            Console.WriteLine();
        }
    }
}
