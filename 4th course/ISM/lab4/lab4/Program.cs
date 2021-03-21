using System;
using System.Collections.Generic;
using System.Linq;

namespace lab4
{
    public class Program
    {
        public static Random Random = new Random();

        delegate double Function(double x, double y);
        private static double FirstIntegralFunction(double x, double y) => Math.Exp(-Math.Pow(x, 6));
        private static double SecondIntegralFunction(double x, double y) 
            => (x * x + y * y) < 1 ? -Math.Log(Math.Sqrt(x * x + y * y)) : 0;
        private static double ThirdIntegralFunction(double x, double y) 
            => (Math.Abs(x) + Math.Abs(y)) < 1 ? Math.Log(x * x + y * y + 1) : 0;

        public static void Main(string[] args)
        {
            CalculateIntegral(new IntegralInfo("e^(-x^6) from -infinity to infinity",
                FirstIntegralFunction, 1.85543867, 0, 1, -2, 2));
            CalculateIntegral(new IntegralInfo("ln(1 / sqrt(x^2 + y^2)) where x^2 + y^2 < 1",
                SecondIntegralFunction, Math.PI / 2, 0, 4, -1, 1, -1, 1));
            CalculateIntegral(new IntegralInfo("ln(x^2 + y^2 + 1) where |x| + |y| < 1",
                ThirdIntegralFunction, 0.550836, 0, 0.7, -1, 1, -1, 1));
            Console.ReadKey();
        }

        private static void CalculateIntegral(IntegralInfo integralInfo)
        {
            int count;
            Console.WriteLine(integralInfo.Info);
            foreach (int n in new int[] { 10, 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000 })
            {
                count = 0;
                var randomX = GetUniformSequence(n, integralInfo.Ax, integralInfo.Bx);
                var randomY = GetUniformSequence(n, integralInfo.Ay ?? 0, integralInfo.By ?? 0);
                var randomValue = GetUniformSequence(n, integralInfo.Min, integralInfo.Max);
                for (int i = 0; i < n; i++)
                {
                    if (randomValue[i] < integralInfo.Function(randomX[i], randomY[i]))
                    {
                        count++;
                    }
                }
                double hitPercentage = (double)count / n;
                double monteCarloValue = integralInfo.Area * hitPercentage;
                Console.WriteLine($"n={n}" + Environment.NewLine + 
                    $"Real value        : {integralInfo.Value:F8}" + Environment.NewLine +
                    $"Monte-Carlo value : {monteCarloValue:F8}");
            }
            Console.WriteLine();
        }

        private static List<double> GetUniformSequence(int amount, double a, double b)
        {
            return GetRandomSequence().Select(x => a + (b - a) * x).ToList();
            IEnumerable<double> GetRandomSequence()
            {
                for (int i = 0; i < amount; i++)
                {
                    yield return Random.NextDouble();
                }
            }
        }

        private class IntegralInfo
        {
            public readonly string Info;
            public readonly Function Function;
            public readonly double Value;
            public readonly double Min;
            public readonly double Max;
            public readonly double Ax;
            public readonly double Bx;
            public readonly double? Ay;
            public readonly double? By;

            public IntegralInfo(string info, Function function, double value, double min, double max, 
                double ax, double bx, double? ay = null, double? by = null)
            {
                Info = info;
                Function = function;
                Value = value;
                Min = min;
                Max = max;
                Ax = ax;
                Bx = bx;
                Ay = ay;
                By = by;
            }

            public double Area => (Bx - Ax) * (Max - Min) * (Ay != null ? (By - Ay).Value : 1);
        }
    }
}
