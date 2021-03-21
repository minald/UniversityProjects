using System;

namespace Lab5Gpss52.Randoms
{
    public class BernulliRandom
    {
        private static readonly Random Rand = new Random();

        public double P { get; set; }

        public BernulliRandom(double p)
        {
            P = p;
        }

        public int Next()
        {
            var a = Rand.NextDouble();
            return a > P ? 0 : 1;
        }

    }
}