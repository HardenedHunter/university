using System;
using Tree;

namespace Tests
{
    class Program
    {
        private static void Swap(ref int a, ref int b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        private static void Test()
        {
            var _tree = new LinkedTree<int>();

            void GetPermutations(int[] list, int k, int m)
            {
                if (k == m)
                {
                    DeleteFromArray(list);
                }
                else
                    for (int i = k; i <= m; i++)
                    {
                        Swap(ref list[k], ref list[i]);
                        GetPermutations(list, k + 1, m);
                        Swap(ref list[k], ref list[i]);
                    }
            }

            void DeleteFromArray(int[] list)
            {
                _tree.Clear();
                _tree.Add(1);
                _tree.Add(2);
                _tree.Add(3);
                _tree.Add(4);
                _tree.Add(5);
                _tree.Add(6);
                _tree.Add(7);
                _tree.Add(8);
                _tree.Add(9);
                _tree.Add(10);
                for (int i = 0; i < list.Length; i++)
                {
                    _tree.Remove(list[i]);
                }
            }

            var array = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            GetPermutations(array, 0, array.Length - 1);
        }

        static void Main(string[] args)
        {
            Test();
            Console.WriteLine();
        }
    }
}