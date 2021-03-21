using System;

namespace Lab5Gpss52.Randoms
{
    public class ExpRandom
    {
        private static readonly Random Rand = new Random();
        public double P { get; set; }

        public ExpRandom()
        {
            P = 0;
        }

        public ExpRandom(double p)
        {
            P = p;
        }

        public double Next()
        {
            return P * (-Math.Log(Rand.NextDouble()));
        }
    }
}