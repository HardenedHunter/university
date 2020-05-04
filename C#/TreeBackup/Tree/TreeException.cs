using System;

namespace Tree
{
    public class TreeException : Exception
    {
        public TreeException(string message) : base(message)
        {
        }

        public TreeException()
        {
        }
    }
}