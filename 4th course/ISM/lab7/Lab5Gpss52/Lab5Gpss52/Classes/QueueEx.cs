using System.Collections.Generic;

namespace Lab5Gpss52.Classes
{
    public class QueueEx
    {
        private List<Transact> _queue;

        public double CommonTime { get; protected set; }
        public int MaxCount { get; protected set; }
        public int Entries { get; protected set; }

        public QueueEx()
        {
            MaxCount = 0;
            Entries = 0;
            _queue = new List<Transact>();
        }

        public void EnQueueTransact(Transact transact)
        {
            transact.EntryTime = transact.Time;
            _queue.Add(transact);
            Entries++;
            if (_queue.Count > MaxCount)
                MaxCount = _queue.Count;
        }

        public void DeQueueTransact(Transact transact)
        {
            //var transact = _queue.Dequeue();
            CommonTime += transact.Time - transact.EntryTime;
            _queue.Remove(transact);
            //return transact;
        }

        public double GetAverageTime()
        {
            return CommonTime/Entries;
        }

        public double GetAverageTransacts(double wholeTime)
        {
            return CommonTime/wholeTime;
        }
    }
}