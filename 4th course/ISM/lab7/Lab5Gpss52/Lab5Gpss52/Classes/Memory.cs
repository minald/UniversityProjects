using Lab5Gpss52.Randoms;

namespace Lab5Gpss52.Classes
{
    public class Memory : IDevice
    {
        private readonly UniformRandom _rand;

        public QueueEx MemQueue { get; protected set; }

        public int Blocks { get; set; }
        public int FreeBlocks { get; protected set; }
        public int MaxBusyBlocks { get; protected set; }
        public double Time { get; set; }

        public Memory(int blocksCount, double lowerBoundReProc, double upperBoundReProc)
        {
            Blocks = blocksCount;
            FreeBlocks = Blocks;
            MaxBusyBlocks = 0;
            Time = 0;
            MemQueue = new QueueEx();
            _rand = new UniformRandom(lowerBoundReProc, upperBoundReProc);
        }

        public bool ReleaseBlock()
        {
            if (FreeBlocks < Blocks)
            {
                FreeBlocks += 1;
                return true;
            }
            return false;
        }

        private bool TakeBlock()
        {
            if (FreeBlocks > 0)
            {
                FreeBlocks -= 1;
                if (MaxBusyBlocks < (Blocks - FreeBlocks))
                    MaxBusyBlocks = Blocks - FreeBlocks;
                return true;
            }
            return false;
        }

        public void EnQueueTransact(Transact transact)
        {
            MemQueue.EnQueueTransact(transact);
        }

        private void DeQueueTransact(Transact transact)
        {
            MemQueue.DeQueueTransact(transact);
        }

        public bool ProcessTransact(Transact transact)
        {
            if (transact.Status == TransactStatus.Prepared)
            {
                transact.Status = TransactStatus.Processed;
                EnQueueTransact(transact);
                return true;
            }

            if (transact.Status == TransactStatus.ReProc)
            {
                transact.Time += _rand.Next();
                transact.Status = TransactStatus.Processed;
                transact.Device = CompSystem.Processor;
                transact.Device.EnQueueTransact(transact);
                return true;
            }

            if(transact.Status==TransactStatus.Finished)
            {
                transact.Status = TransactStatus.Released;
                ReleaseBlock();
                Time = transact.Time;
                return true;
            }

            if (TakeBlock())
            {
                DeQueueTransact(transact);
                transact.Device = CompSystem.Processor;
                transact.Device.EnQueueTransact(transact);
                return true;
            }
            else
            {
                if (transact.Time < Time)
                    transact.Time = Time;
                transact.Status = TransactStatus.Waiting;
                return false;
            }
            
        }

        public double LowerBoundReProc
        {
            get { return _rand.LowerBound; }
            set { _rand.LowerBound = value; }
        }

        public double UpperBoundReProc
        {
            get { return _rand.UpperBound; }
            set { _rand.UpperBound = value; }
        }
    }
}