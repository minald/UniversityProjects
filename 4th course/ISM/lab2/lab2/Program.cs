using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2
{
    public class Program
    {
        #region Constants

        public const int N = 1000;
        public const int CriteriaItemsAmount = 10;
        public const double BernulliP = 0.5;
        public const int BinomialM = 5;
        public const double BinomialP = 0.25;
        public const double GeometricalP = 0.6;
        public const double PuassonLambda = 2;
        public const int NegativeBinomialR = 5;
        public const double NegativeBinomialP = 0.25;
        public static Dictionary<int, double> Pearson0_05Quantiles = new Dictionary<int, double>()
        {
            { 1, 3.8415 },
            { 2, 5.9915 },
            { 3, 7.8147 },
            { 4, 9.4877 },
            { 5, 11.07 },
            { 9, 16.919 },
            { 49, 66.339 }
        };

        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine($"N={N}");
            DisplayResults($"P={BernulliP}", 2, GetBernulliSequence(BernulliP),
                BernulliProbabilityFunction, BernulliMathematicalExpectation, BernulliDispersion);
            DisplayResults($"M={BinomialM}, P={BinomialP}", BinomialM + 1, GetBinomialSequence(BinomialM, BinomialP),
                BinomialProbabilityFunction, BinomialMathematicalExpectation, BinomialDispersion);
            DisplayResults($"P={GeometricalP}", CriteriaItemsAmount, GetGeometricalSequence(GeometricalP),
                GeometricalProbabilityFunction, GeometricalMathematicalExpectation, GeometricalDispersion);
            DisplayResults($"Lamdba={PuassonLambda}", CriteriaItemsAmount, GetPuassonSequence(PuassonLambda), 
                PuassonProbabilityFunction, PuassonMathematicalExpectation, PuassonDispersion);
            DisplayResults($"R={NegativeBinomialR}, P={NegativeBinomialP}", CriteriaItemsAmount, 
                GetNegativeBinomialSequence(NegativeBinomialR, NegativeBinomialP), 
                NegativeBinomialProbabilityFunction, NegativeBinomialMathematicalExpectation, NegativeBinomialDispersion);
            Console.ReadKey();
        }

        private static void DisplayResults(string parameters, int criteriaItemsAmount, List<double> results,
            ProbabilityFunction probabilityFunction, MathematicalExpectation mathematicalExpectation, Dispersion dispersion)
        {
            Console.WriteLine(Environment.NewLine + 
                $"-----{dispersion.Method.Name.Replace("Dispersion", "")} distribution ({parameters})-----");
            results.Take(30).ToList().ForEach(x => Console.Write($"{x:F0} "));
            Console.Write(Environment.NewLine + $"{N} items: ");
            for (int i = 0; i < Math.Min(7, criteriaItemsAmount); i++)
            {
                Console.Write($"{i}({results.Count(x => x == i)}) ");
            }
            Console.WriteLine();
            Console.WriteLine($"Practical  : Average={results.Average():F5}, Dispersion={CalculateDispersion(results.ToList()):F5}");
            Console.WriteLine($"Theoretical: Average={mathematicalExpectation():F5}, Dispersion={dispersion():F5}");
            CheckPearsonCriteria(GetSortedList(results), probabilityFunction, criteriaItemsAmount);

            double CalculateDispersion(List<double> list) => list.Sum(x => Math.Pow(x - list.Average(), 2)) / list.Count;
            List<double> GetSortedList(List<double> list) => list.OrderBy(x => x).ToList();
        }

        private static void CheckPearsonCriteria(List<double> list, ProbabilityFunction function, int criteriaItemsAmount)
        {
            var probabilityFunctionValues = GetProbabilityFunctionValues();
            var valuesAmount = GetAmountByValues();
            double value = 0;
            for (int i = 0; i < criteriaItemsAmount; i++)
            {
                if (probabilityFunctionValues[i] != 0)
                {
                    value += Math.Pow(valuesAmount[i] - N * probabilityFunctionValues[i], 2) / (N * probabilityFunctionValues[i]);
                }
            }
            Console.WriteLine($"Pearson criterion: {DisplayCriteriaResults(Pearson0_05Quantiles[criteriaItemsAmount - 1])}");

            List<double> GetProbabilityFunctionValues() //For Puasson: 0.220, 0.333, 0.252, 0.127, 0.048, 0.015, 0.005
            {
                return GetIEnumerableProbabilityFunctionValues().ToList();
                IEnumerable<double> GetIEnumerableProbabilityFunctionValues()
                {
                    for (int i = 0; i < criteriaItemsAmount; i++)
                    {
                        yield return function(i);
                    }
                }
            }
            List<int> GetAmountByValues()
            {
                return GetIEnumerableAmountByValues().ToList();
                IEnumerable<int> GetIEnumerableAmountByValues()
                {
                    for (int i = 0; i < criteriaItemsAmount; i++)
                    {
                        yield return list.Count(x => x == i);
                    }
                }
            }
            string DisplayCriteriaResults(double quantile) => value < quantile ?
                $"{value:F5} < {quantile:F3}, so it's passed" : $"{value:F5} > {quantile:F3}, so it isn't passed";
        }

        #region Sequence modeling algorithms

        private static List<double> GetBernulliSequence(double p) =>
            GetRandomSequence(N).Select(x => x <= p ? 1.0 : 0.0).ToList();

        private static List<double> GetBinomialSequence(int m, double p)
        {
            return GetBinomialSequence().ToList();
            IEnumerable<double> GetBinomialSequence()
            {
                var randomSequence = GetRandomSequence(N * m);
                for (int i = 0; i < N; i++)
                {
                    var randomSubsequence = randomSequence.Skip(i * m).Take(m).ToList();
                    double value = 0;
                    randomSubsequence.ForEach(x => value += p > x ? 1 : 0);
                    yield return value;
                }
            }
        }

        private static List<double> GetGeometricalSequence(double p) =>
            GetRandomSequence(N).Select(x => Math.Floor(Math.Log(x) / Math.Log(1 - p))).ToList();

        private static List<double> GetPuassonSequence(double lamdba)
        {
            return GetPuassonSequence().ToList();
            IEnumerable<double> GetPuassonSequence()
            {
                var randomSequence = GetRandomSequence((int)(N * 2 * lamdba));
                var eInMinusLambda = Math.Pow(Math.E, -lamdba);
                int randomSequenceCounter = 0;
                for (int i = 0; i < N; i++)
                {
                    double currentMultiplication = randomSequence.ElementAt(randomSequenceCounter);
                    randomSequenceCounter++;
                    double counter = 0;
                    while (currentMultiplication >= eInMinusLambda)
                    {
                        counter++;
                        currentMultiplication *= randomSequence.ElementAt(randomSequenceCounter);
                        randomSequenceCounter++;
                    }

                    yield return counter;
                }
            }
        }

        private static List<double> GetNegativeBinomialSequence(int r, double p)
        {
            return GetNegativeBinomialSequence().ToList();
            IEnumerable<double> GetNegativeBinomialSequence()
            {
                var randomSequence = GetRandomSequence((int)(N * 2 * NegativeBinomialMathematicalExpectation()));
                int randomSequenceCounter = 0;
                for (int i = 0; i < N; i++)
                {
                    var smallerThanPCounter = 0;
                    var biggerThanPCounter = 0;
                    while (smallerThanPCounter < r)
                    {
                        var randomElement = randomSequence.ElementAt(randomSequenceCounter);
                        randomSequenceCounter++;
                        if (randomElement < p)
                        {
                            smallerThanPCounter++;
                        }
                        else
                        {
                            biggerThanPCounter++;
                        }
                    }

                    yield return biggerThanPCounter;
                }
            }
        }

        #endregion

        #region Probability functions

        delegate double ProbabilityFunction(int x);

        private static double BernulliProbabilityFunction(int x) => x == 1 ? BernulliP : (x == 0 ? 1 - BernulliP : 0);

        private static double BinomialProbabilityFunction(int x) =>
            Math.Pow(BinomialP, x) * Math.Pow(1 - BinomialP, BinomialM - x) *
                Factorial(BinomialM) / (Factorial(BinomialM - x) * Factorial(x));

        private static double GeometricalProbabilityFunction(int x) => GeometricalP * Math.Pow(1 - GeometricalP, x);

        private static double PuassonProbabilityFunction(int x) =>
            Math.Pow(Math.E, -PuassonLambda) * Math.Pow(PuassonLambda, x) / Factorial(x);

        private static double NegativeBinomialProbabilityFunction(int x) =>
            Math.Pow(NegativeBinomialP, NegativeBinomialR) * Math.Pow(1 - NegativeBinomialP, x) *
                Factorial(x + NegativeBinomialR - 1) / (Factorial(NegativeBinomialR - 1) * Factorial(x));

        #endregion

        #region Mathematical expectations

        delegate double MathematicalExpectation();

        private static double BernulliMathematicalExpectation() => BernulliP;

        private static double BinomialMathematicalExpectation() => BinomialM * BinomialP;

        private static double GeometricalMathematicalExpectation() => (1 - GeometricalP) / GeometricalP;

        private static double PuassonMathematicalExpectation() => PuassonLambda;

        private static double NegativeBinomialMathematicalExpectation() =>
            NegativeBinomialR * (1 - NegativeBinomialP) / NegativeBinomialP;

        #endregion

        #region Dispersions

        delegate double Dispersion();

        private static double BernulliDispersion() => BernulliP * (1 - BernulliP);

        private static double BinomialDispersion() => BinomialM * BinomialP * (1 - BinomialP);

        private static double GeometricalDispersion() => (1 - GeometricalP) / Math.Pow(GeometricalP, 2);

        private static double PuassonDispersion() => PuassonLambda;

        private static double NegativeBinomialDispersion() =>
            NegativeBinomialR * (1 - NegativeBinomialP) / Math.Pow(NegativeBinomialP, 2);

        #endregion

        #region Supporting functions

        private static long Factorial(long x) => x <= 1 ? 1 : x * Factorial(x - 1);

        private static List<double> GetRandomSequence(int amount)
        {
            return GetRandomSequence().ToList();
            IEnumerable<double> GetRandomSequence()
            {
                var random = new Random();
                for (int i = 0; i < amount; i++)
                {
                    yield return random.NextDouble();
                }
            }
        }

        #endregion
    }
}
