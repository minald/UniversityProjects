namespace Lab5Gpss52.Classes
{
    public interface IDevice
    {
        void EnQueueTransact(Transact transact);
        bool ProcessTransact(Transact transact);
    }
}