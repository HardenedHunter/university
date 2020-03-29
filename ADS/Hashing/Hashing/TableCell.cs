namespace Hashing
{
    public class TableCell<T>
    {
        public T Info { get; set; }
        public int Next { get; set; }

        public TableCell(T info, int next = -1)
        {
            Info = info;
            Next = next;
        }
    }
}