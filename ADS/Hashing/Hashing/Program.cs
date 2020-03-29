using System.IO;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(File.OpenRead("../../test.txt")))
            {

                if (CarInfo.TryReadAsText(reader, out var info))
                {
                    info.WriteToConsole();
                }
            }
        }
    }
}
