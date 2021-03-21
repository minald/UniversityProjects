namespace Lab5Gpss52.Classes
{
    public class Transact
    {
        public double Time { get; set; }
        public double EntryTime { get; set; }
        public TransactStatus Status { get; set; }
        public IDevice Device { get; set; }
    }
}