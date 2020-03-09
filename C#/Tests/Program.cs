using System;
using System.Runtime.InteropServices;
using Tree;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var tree =  new LinkedTree<int>(3);
            tree.Add(5);


            //            const int key = 8;
            //            var keys = new List<int> {0, 2, 4, 6, 8};
            //            var children = new List<int> {0, 1, 2, 3, 4, 5};
            //            if (keys.Count == 0) Console.WriteLine("null");
            //            else
            //            {
            //                int location = 0;
            //                //Use IndexInSorted
            //                while (location < keys.Count && key.CompareTo(keys[location]) >= 0)
            //                {
            //                    location++;
            //                }
            //
            //                int childIndex = key.CompareTo(keys[location]) == 0 ? location : location - 1;
            //                Console.WriteLine(children[childIndex + 2]);
            //            }

        }
    }
}
