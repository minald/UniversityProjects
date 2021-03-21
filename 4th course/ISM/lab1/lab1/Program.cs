using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1
{
    public class Program
    {
        public static Dictionary<double, double> KolmogorovQuantiles = new Dictionary<double, double>()
        {
            { 0.005, 1.73 },
            { 0.01, 1.63 },
            { 0.025, 1.48 },
            { 0.05, 1.36 },
            { 0.10, 1.22 },
            { 0.15, 1.14 },
            { 0.20, 1.07 },
            { 0.25, 1.02 }
        };

        public static Dictionary<double, double> Pearson49Quantiles = new Dictionary<double, double>()
        {
            { 0.01, 74.919 },
            { 0.025, 70.222 },
            { 0.05, 66.339 },
            { 0.10, 62.038 },
            { 0.20, 57.059 },
            { 0.30, 53.67 }
        };

        public const int K = 64;
        public const uint M = 2147483648; //2^31
        public const int Beta = 79507;
        public const double Epsilon = 0.05;
        public const int N = 1000;
        public const int IntervalsAmount = 50;

        delegate double DistributionFunction(double x);

        private static double Uniform(double x) => x;

        readonly static DistributionFunction function = new DistributionFunction(Uniform);

        static void Main(string[] args)
        {
            Console.WriteLine($"K={K}, M={M}, Beta={Beta}, Epsilon={Epsilon}, N={N}, IntervalsAmount={IntervalsAmount}" + Environment.NewLine);
            Console.WriteLine("--------------------Multiplicative congruential method--------------------");
            DisplayResults(GetMultiplicativeCongruentialSequence(N));
            Console.WriteLine(Environment.NewLine + "--------------------MacLaren-Marsaglia method--------------------");
            DisplayResults(GetMacLarenMarsagliaSequence(N));
            Console.ReadKey();
        }

        private static void DisplayResults(List<double> results)
        {
            results.Take(10).ToList().ForEach(x => Console.Write($"{x:F5} "));
            Console.WriteLine();
            CheckKolmogorovCriteria(GetSortedList(results), function);
            CheckPearsonCriteria(GetSortedList(results), function);
        }

        private static List<double> GetMultiplicativeCongruentialSequence(int amount)
        {
            var multiplicativeList = new List<double>();
            multiplicativeList.Add((double)Beta / M);
            for (int i = 1; i < amount; i++)
            {
                long x = (long)(Beta * multiplicativeList[i - 1] * M);
                double value = (double)(x % M) / M;
                multiplicativeList.Add(value);
            }

            return multiplicativeList;
        }

        private static List<double> GetMacLarenMarsagliaSequence(int amount)
        {
            var maclarenList = new List<double>();
            var firstList = GetMultiplicativeCongruentialSequence(amount + K);
            var secondList = GetRandomSequence(amount).ToList();
            var supportingList = firstList.Take(K).ToList();
            for (int i = 0; i < amount; i++)
            {
                int index = (int)(secondList[i] / M * K);
                double value = supportingList[index];
                maclarenList.Add(value);
                supportingList[index] = firstList[K + i];
            }

            return maclarenList;
        }

        private static IEnumerable<double> GetRandomSequence(int amount)
        {
            var random = new Random();
            for (int i = 0; i < amount; i++)
            {
                yield return random.NextDouble();
            }
        }

        private static List<double> GetSortedList(List<double> list) => list.OrderBy(x => x).ToList();

        private static void CheckKolmogorovCriteria(List<double> list, DistributionFunction function)
        {
            var distributionFunctionValues = GetDistributionFunctionValues(function, list.Count).ToList();
            double maxDiff = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (Math.Abs(list[i] - distributionFunctionValues[i]) > maxDiff)
                {
                    maxDiff = Math.Abs(list[i] - distributionFunctionValues[i]);
                }
                if (Math.Abs(list[i] - distributionFunctionValues[i + 1]) > maxDiff)
                {
                    maxDiff = Math.Abs(list[i] - distributionFunctionValues[i + 1]);
                }
            }

            var value = maxDiff * Math.Sqrt(list.Count);
            Console.WriteLine($"Kolmogorov criterion: {DisplayCriteriaResults(value, KolmogorovQuantiles[Epsilon])}");
        }

        private static void CheckPearsonCriteria(List<double> list, DistributionFunction function)
        {
            var distributionFunctionValues = GetDistributionFunctionValues(function, IntervalsAmount).ToList();
            var probabilityFunctionValues = GetProbabilityFunctionValues(distributionFunctionValues).ToList();
            var intervals = GetAmountByIntervals(list).ToList();
            double value = 0;
            for (int i = 0; i < IntervalsAmount; i++)
            {
                value += Math.Pow(intervals[i] - N * probabilityFunctionValues[i], 2) / (N * probabilityFunctionValues[i]);
            }

            Console.WriteLine($"Pearson criterion: {DisplayCriteriaResults(value, Pearson49Quantiles[Epsilon])}");
        }

        //For Puasson: 0, 0.220, 0.553, 0.805, 0.932, 0.980, 0.995, 1
        private static IEnumerable<double> GetDistributionFunctionValues(DistributionFunction function, int amount)
        {
            for (int i = 0; i < amount + 1; i++)
            {
                yield return function((double)i / amount);
            }
        }

        //For Puasson: 0.220, 0.333, 0.252, 0.127, 0.048, 0.015, 0.005
        private static IEnumerable<double> GetProbabilityFunctionValues(IEnumerable<double> distributionFunctionValues)
        {
            for (int i = 1; i < distributionFunctionValues.Count(); i++)
            {
                yield return distributionFunctionValues.ElementAt(i) - distributionFunctionValues.ElementAt(i - 1);
            }
        }

        private static IEnumerable<int> GetAmountByIntervals(List<double> list)
        {
            for (int i = 0; i < IntervalsAmount; i++)
            {
                yield return list.Count(x => x > (double)i / IntervalsAmount && x < (double)(i + 1) / IntervalsAmount);
            }
        }

        private static string DisplayCriteriaResults(double value, double quantile) => value < quantile ?
            $"{value:F5} < {quantile:F3}, so it's passed" : $"{value:F5} > {quantile:F3}, so it isn't passed";
    }
}
