using System;
using System.ComponentModel.Design;
using System.Drawing;
using Tree;

namespace Tests
{
    class Program
    {
        // static void PrintWrapper(LinkedTree<int> tree)
        // {
        //     PrintTree(tree);
        //     Console.WriteLine("Level: " + tree.Level);
        //     Console.WriteLine();
        // }
        //
        // static void PrintTree(LinkedTree<int> tree)
        // {
        //     PrintNode(tree._root);
        // }
        //
        // static void PrintNode(LinkedNode<int> linkedNode)
        // {
        //     linkedNode.Keys.Print();
        //     if (linkedNode is InternalLinkedNode<int> tmp)
        //         foreach (var tmpChild in tmp.Children)
        //             PrintNode(tmpChild);
        // }

        static void Main(string[] args)
        {
            var l = new List<int> {1, 2, 3, 4, 5};
            var a = new ArrayList<int>(){ 1, 2, 3, 4, 5 };

            l.Insert(0, 5);
            a.Insert(0, 5);

            Console.WriteLine(l);
            Console.WriteLine(a);


            // var tree = new LinkedTree<int>(2);
            // tree.Add(1);
            // PrintWrapper(tree);
            // tree.Add(2);
            // PrintWrapper(tree);
            // tree.Add(3);
            // PrintWrapper(tree);
            // tree.Add(4);
            // PrintWrapper(tree);
            // tree.Add(5);
            // PrintWrapper(tree);
            // tree.Add(6);
            // PrintWrapper(tree);
            // tree.Add(7);
            // PrintWrapper(tree);
            // tree.Add(8);
            // PrintWrapper(tree);
            // tree.Add(9);
            // PrintWrapper(tree);
            // tree.Add(10);
            // PrintWrapper(tree);
            //
            // if (TreeUtils.CheckForAll(tree, elem => elem < 11))
            //     Console.WriteLine("True");
            // Console.WriteLine("Count: " + tree.Count);
            // for (int i = -123; i < 123; i++)
            // {
            //     if (tree.Contains(i))
            //         Console.WriteLine(i);
            // }
            // tree.Remove(10);
            // PrintWrapper(tree);
            // tree.Remove(9);
            // PrintWrapper(tree);
            // tree.Remove(1);
            // PrintWrapper(tree);
            // tree.Remove(2);
            // PrintWrapper(tree);
            // tree.Remove(3);
            // PrintWrapper(tree);
            // tree.Remove(6);
            // PrintWrapper(tree);
            // tree.Remove(4);
            // PrintWrapper(tree);
            // tree.Remove(7);
            // PrintWrapper(tree);


            // tree.Remove(6);
            // PrintWrapper(tree);
            // tree.Remove(3);
            // PrintWrapper(tree);
            Console.WriteLine();
        }
    }
}