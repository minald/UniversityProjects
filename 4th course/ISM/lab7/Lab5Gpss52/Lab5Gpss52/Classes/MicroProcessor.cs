using System;
using Lab5Gpss52.Randoms;

namespace Lab5Gpss52.Classes
{
    public class MicroProcessor
    {
        private readonly ExpRandom _rand = new ExpRandom();

        public double Time { get; set; }
        public int Entries { get; protected set;}
        public double ProcTime { get; protected set; }

        public MicroProcessor()
        {
            Entries = 0;
            ProcTime = 0;
            Time = 0;
        }

        public MicroProcessor(double processorTime)
        {
            Entries = 0;
            _rand.P = processorTime;
        }

        public void ProcessTransact(Transact transact)
        {
            Entries++;
            var time = _rand.Next();
            ProcTime += time;
            transact.Time += time;
            Time = transact.Time;
        }

        public double GetAverageProcTime()
        {
            return ProcTime/Entries;
        }

        public double GetRelativeWorkTime(double wholeTime)
        {
            return ProcTime / wholeTime;
        }
    }
}