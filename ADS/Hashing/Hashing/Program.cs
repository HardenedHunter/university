using System;
using System.Data;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable<int>(); 
            table.DebugPrint();
            table.Add(2);
            table.Add(3);
            table.Add(5);
            table.Add(6);
            table.Add(8);
            table.Add(10);
            table.Add(7);
            table.Add(9);
            table.Add(11);
            table.Add(1);
            table.Add(13);
            table.Delete(13);
            table.Delete(7);
            table.Delete(6);
        }
    }
}
