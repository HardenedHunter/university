using System;
using System.IO;

namespace Hashing
{
    class FileUtils
    {
        public static bool GetValueFromFile(StreamReader reader, ref string value)
        {
            value = "";
            bool result = !reader.EndOfStream;
            if (result)
            {
                value = reader.ReadLine();
                if (value == null) throw new NullReferenceException("Ошибка чтения из файла.");
                int colonIndex = value.IndexOf(':');
                result = colonIndex >= 0 && colonIndex + 1 < value.Length;
                if (result)
                {
                    value = value.Substring(colonIndex + 1).Trim();
                }
            }

            return result;
        }
    }
}