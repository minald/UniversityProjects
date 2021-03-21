using System;
using System.Linq;

namespace lab5
{
    public class Program
    {
        public static Random Random = new Random();
        public const int n = 3;
        public static double[,] A = new double[n, n] { { -0.2, -0.1, 0.3 }, { 0.3, 0.1, 0.2 }, { -0.4, -0.5, 0.0 } };
        public static double[] f = new double[n] { 2, 3, 3 };

        public static void Main(string[] args)
        {
            Console.WriteLine("C - chain length, R - realizations amount");
            Console.WriteLine($"Real            : x1=1.4545, x2=3.9200, x3=0.4582");
            foreach (int chainLength in new int[] { 1000, 2000 })
            {
                foreach (int realizationsAmount in new int[] { 10000, 20000, 30000 })
                {
                    double x1 = GetRoot(chainLength, realizationsAmount, new double[n] { 1, 0, 0 });
                    double x2 = GetRoot(chainLength, realizationsAmount, new double[n] { 0, 1, 0 });
                    double x3 = GetRoot(chainLength, realizationsAmount, new double[n] { 0, 0, 1 });
                    Console.WriteLine($"C={chainLength}, R={realizationsAmount} : x1={x1:F4}, x2={x2:F4}, x3={x3:F4}");
                }
            }
            Console.ReadKey();
        }

        private static double GetRoot(int chainLength, int realizationsAmount, double[] h)
        {
            double[] ksi = Enumerable.Repeat(0.0, realizationsAmount).ToArray();
            int[] i = new int[chainLength + 1]; //Markov Chain
            double[] Q = new double[chainLength + 1]; //Weights of Markov Chain States
            //Markov Chain modeling
            for (int j = 0; j < realizationsAmount; j++)
            {
                for (int k = 0; k <= chainLength; k++)
                {
                    i[k] = GetIndex(Random.NextDouble());
                }
                //Weights counting
                Q[0] = 3 * h[i[0]];
                for (int k = 1; k <= chainLength; k++)
                {
                    Q[k] = 3 * Q[k - 1] * A[i[k - 1], i[k]];
                }
                for (int k = 0; k <= chainLength; k++)
                {
                    ksi[j] += Q[k] * f[i[k]];
                }
            }
            return ksi.Sum() / realizationsAmount;
        }

        private static int GetIndex(double value)
        {
            if (value < 0.333)
            {
                return 0;
            }
            if (value < 0.667)
            {
                return 1;
            }
            return 2;
        }
    }
}
