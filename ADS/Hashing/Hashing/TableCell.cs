namespace Hashing
{
    public class TableCell
    {
        public CarInfo Info { get; set; }
        public int Next { get; set; }

        public TableCell(CarInfo info, int next = -1)
        {
            Info = info;
            Next = next;
        }
    }
}