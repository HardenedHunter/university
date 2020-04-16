using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace RadixSort
{
    static class Program
    {
        private const int Base = 2;
        private const int Length = sizeof(int) * 8;


        static void LsdRadixSort(int[] items)
        {
            var buckets = new List<int>[Base];
            for (var i = 0; i < Base; ++i)
            {
                buckets[i] = new List<int>();
            }

            for (var step = 0; step < Length; ++step)
            {
                foreach (var item in items)
                {
                    int index = (item & (1 << step)) > 0 ? 1 : 0;
                    buckets[index].Add(item);
                }

                var j = 0;
                foreach (var bucket in buckets)
                {
                    foreach (var sortedItem in bucket)
                    {
                        items[j] = sortedItem;
                        j++;
                    }
                }

                foreach (var bucket in buckets)
                {
                    bucket.Clear();
                }
            }
        }

        // static void LsdRadixSort(int[] items, int length = 2)
        // {
        //     var buckets = new List<int>[Base];
        //     for (var i = 0; i < Base; ++i)
        //     {
        //         buckets[i] = new List<int>();
        //     }
        //
        //     for (var step = 0; step < length; ++step)
        //     {
        //         foreach (var item in items)
        //         {
        //             var index = item % (int)Math.Pow(Base, step + 1) / (int)Math.Pow(Base, step);
        //             buckets[index].Add(item);
        //         }
        //
        //         var j = 0;
        //         foreach (var bucket in buckets)
        //         {
        //             foreach (var sortedItem in bucket)
        //             {
        //                 items[j] = sortedItem;
        //                 j++;
        //             }
        //         }
        //
        //         foreach (var bucket in buckets)
        //         {
        //             bucket.Clear();
        //         }
        //     }
        // }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var arr = new int[] {6, 1331, 3123, 7, 12, 5, 4, 134, 2, 9};
            var start = String.Join(" ", arr);
            LsdRadixSort(arr);
            MessageBox.Show(start + "\n" + String.Join(" ", arr), "", MessageBoxButtons.OK);
            // Application.Run(new Form1());

        }
    }
}
