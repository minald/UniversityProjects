using System;
using Lab5Gpss52.Randoms;

namespace Lab5Gpss52.Classes
{
    public class Processor : IDevice
    {
        private BernulliRandom _rand;
        
        public QueueEx ProcQueue { get; protected set; }
        public MicroProcessor Proc1 { get; protected set; }
        public MicroProcessor Proc2 { get; protected set; }

        public Processor(double procTime1, double procTime2)
        {
            ProcQueue = new QueueEx();
            Proc1 = new MicroProcessor(procTime1);
            Proc2 = new MicroProcessor(procTime2);
            _rand = new BernulliRandom(0.6);
        }

        public void EnQueueTransact(Transact transact)
        {
            ProcQueue.EnQueueTransact(transact);
        }

        private void DeQueueTransact(Transact transact)
        {
            ProcQueue.DeQueueTransact(transact);
        }

        public bool ProcessTransact(Transact transact)
        {
            if (Proc1.Time <= transact.Time)
            {
                DeQueueTransact(transact);
                Proc1.ProcessTransact(transact);
                PostProcess(transact);
                return true;
            }
            if (Proc2.Time <= transact.Time)
            {
                DeQueueTransact(transact);
                Proc2.ProcessTransact(transact);
                PostProcess(transact);
                return true;
            }
            transact.Time = (Proc1.Time < Proc2.Time) ? Proc1.Time : Proc2.Time;
            return false;
        }

        private void PostProcess(Transact transact)
        {
            var r = _rand.Next();
            if (r == 0)
            {
                transact.Status = TransactStatus.ReProc;
                transact.Device = CompSystem.Memory;
            }
            else
            {
                transact.Status = TransactStatus.Finished;
                transact.Device = CompSystem.Memory;
            }
        }


    }
}