using System;
using System.IO;

namespace ExternalSorting
{
    public class FileSorter
    {
        public static void Sort(string fileName, Func<Country, Country, bool> less)
        {
            var origin = new Sequence(fileName, less);
            var first = new Sequence("help1.bin", less);
            var second = new Sequence("help2.bin", less);
            int seriesCount;

            do
            {
                origin.Distribute(first, second);
                seriesCount = origin.Merge(first, second);
            } while (seriesCount > 1);

            File.Delete("help1.bin");
            File.Delete("help2.bin");
        }
    }
}