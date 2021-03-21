using System;
using System.Collections.Generic;
using System.Linq;
using Lab5Gpss52.Classes;

namespace Lab5Gpss52
{
    public class CompSystem
    {
        private TransactGenerator _transactGenerator;
        private List<Transact> _transacts;

        public static IDevice Processor { get; protected set; }
        public static IDevice Memory { get; protected set; }

        public CompSystem(int transactCount, double lbRand, double ubRand, double lbRandMem, double ubRandMem, int memBlocks, double procTime1, double procTime2)
        {
            _transactGenerator = new TransactGenerator(lbRand,ubRand);
            Memory = new Memory(memBlocks, lbRandMem, ubRandMem);
            Processor = new Processor(procTime1, procTime2);
            _transacts = _transactGenerator.Generate(transactCount);
        }

        public void RunProcess()
        {
            _transacts = _transacts.OrderBy(t=>t.Time).ToList();
            foreach (var t in _transacts)
            {
                t.Device = Memory;
            }

            var transact = _transacts.FirstOrDefault(t => t.Status!=TransactStatus.Released);
            while(transact != null)
            {
                if (transact.Device.ProcessTransact(transact))
                    ClearStatus();
                _transacts = _transacts.OrderBy(t => t.Time).ToList();
                transact = _transacts.FirstOrDefault(t => (t.Status != TransactStatus.Released) && (t.Status != TransactStatus.Waiting));
            }
        }

        private void ClearStatus()
        {
            foreach (var transact in _transacts)
            {
                if (transact.Status == TransactStatus.Waiting)
                    transact.Status = TransactStatus.Processed;
            }
        }

        public void GenerateReport()
        {
            _transacts = _transacts.OrderBy(t => t.Time).ToList();
            var wholeTime = _transacts.Last().Time;

            Console.WriteLine("Whole time {0}", wholeTime);

            Console.WriteLine("Memory: Max busy blocks count {0}", ((Memory)Memory).MaxBusyBlocks);
            Console.WriteLine("Memory queue:");
            Console.WriteLine("\tMax count {0}", ((Memory)Memory).MemQueue.MaxCount);
            Console.WriteLine("\tEntries {0}", ((Memory)Memory).MemQueue.Entries);
            Console.WriteLine("\tAverage time in queue {0}", ((Memory)Memory).MemQueue.GetAverageTime());
            Console.WriteLine("\tAverage transacts in queue {0}", ((Memory)Memory).MemQueue.GetAverageTransacts(wholeTime));
            
            Console.WriteLine("Processor queue:");
            Console.WriteLine("\tMax count {0}", ((Processor)Processor).ProcQueue.MaxCount);
            Console.WriteLine("\tEntries {0}", ((Processor)Processor).ProcQueue.Entries);
            Console.WriteLine("\tAverage time in queue {0}", ((Processor)Processor).ProcQueue.GetAverageTime());
            Console.WriteLine("\tAverage transacts in queue {0}", ((Processor)Processor).ProcQueue.GetAverageTransacts(wholeTime));

            Console.WriteLine("Processor 1:");
            Console.WriteLine("\tEntries {0}", ((Processor)Processor).Proc1.Entries);
            Console.WriteLine("\tAverage time {0}",((Processor) Processor).Proc1.GetAverageProcTime());
            Console.WriteLine("\tRelative work time {0}", ((Processor)Processor).Proc1.GetRelativeWorkTime(wholeTime));

            Console.WriteLine("Processor 2:");
            Console.WriteLine("\tEntries {0}", ((Processor)Processor).Proc2.Entries);
            Console.WriteLine("\tAverage time {0}", ((Processor)Processor).Proc2.GetAverageProcTime());
            Console.WriteLine("\tRelative work time {0}", ((Processor)Processor).Proc2.GetRelativeWorkTime(wholeTime));
        }
    }
}