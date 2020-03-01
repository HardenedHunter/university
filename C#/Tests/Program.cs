using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            // System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
            // list.Insert(0, 3);
            // foreach (var i in list)
            // {
            //     Console.WriteLine(i);
            // }


            List<int> l = new List<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(40);
            // Console.WriteLine($"{l[0]} {l[1]} {l[2]} {l[3]}");
            l.Insert(4, 10);

            foreach (var i in l)
            {
                Console.WriteLine(i);
            }
            // Console.WriteLine(l.IndexOf(4));
            //            Console.WriteLine(l[1]);
        }
    }
}
