// ReSharper disable StringLiteralTypo

namespace Tree
{
    public class ImmutableTreeException : TreeException
    {
        public ImmutableTreeException(string message) : base(message)
        {
        }

        public ImmutableTreeException() : base("Попытка изменить неизменяемое дерево.")
        {
        }
    }
}