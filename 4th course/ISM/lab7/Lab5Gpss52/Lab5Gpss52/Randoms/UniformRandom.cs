using System;

namespace Lab5Gpss52.Randoms
{
    public class UniformRandom
    {
        private static readonly Random Rand = new Random();

        public double LowerBound { get; set; }
        public double UpperBound { get; set; }

        public UniformRandom(double lowerBound, double upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        public double Next()
        {
            var a = Rand.NextDouble();
            return a*(UpperBound - LowerBound) + LowerBound;
        }
    }
}