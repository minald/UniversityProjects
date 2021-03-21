using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5Gpss52
{
    class Program
    {
        static void Main(string[] args)
        {
            //CompSystem(int transactCount, double lbRand, double ubRand, double lbRandMem, double ubRandMem, 
            //int memBlocks, double procTime1, double procTime2)
            var compSystem = new CompSystem(100, 1, 4, 2, 6, 6, 2, 4);
            compSystem.RunProcess();
            compSystem.GenerateReport();
            Console.ReadLine();
        }
    }
}
