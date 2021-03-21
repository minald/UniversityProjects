using System;
using System.Collections.Generic;
using System.Linq;

namespace lab3
{
    public class Program
    {
        #region Constants

        public const int N = 1000;
        public const double NormalM = -3;
        public const double NormalS2 = 16;
        public const double LognormalM = 1;
        public const double LognormalS2 = 4;
        public const double CauchyX0 = 1;
        public const double CauchyGamma = 2;
        public const double UniformA = 0;
        public const double UniformB = 10;
        public const double WeibullGnedenkoLambda = 1;
        public const double WeibullGnedenkoK = 2;
        public const double LogisticMu = 2;
        public const double LogisticS = 1;

        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine($"N={N}");
            DisplayResults($"M={NormalM}, S2={NormalS2}", GetNormalSequence(NormalM, NormalS2),
                NormalProbabilityFunction, NormalMathematicalExpectation, NormalDispersion);
            DisplayResults($"M={LognormalM}, S2={LognormalS2}", GetLognormalSequence(LognormalM, LognormalS2),
                LognormalProbabilityFunction, LognormalMathematicalExpectation, LognormalDispersion);
            DisplayResults($"X0={CauchyX0}, Gamma={CauchyGamma}", GetCauchySequence(CauchyX0, CauchyGamma),
                CauchyProbabilityFunction, CauchyMathematicalExpectation, CauchyDispersion);
            DisplayResults($"A={UniformA}, B={UniformB}", GetUniformSequence(UniformA, UniformB),
                UniformProbabilityFunction, UniformMathematicalExpectation, UniformDispersion);
            DisplayResults($"Lambda={WeibullGnedenkoLambda}, K={WeibullGnedenkoK}",
                GetWeibullGnedenkoSequence(WeibullGnedenkoLambda, WeibullGnedenkoK),
                WeibullGnedenkoProbabilityFunction, WeibullGnedenkoMathematicalExpectation, WeibullGnedenkoDispersion);
            DisplayResults($"Mu={LogisticMu}, S={LogisticS}", GetLogisticSequence(LogisticMu, LogisticS),
                LogisticProbabilityFunction, LogisticMathematicalExpectation, LogisticDispersion);
            Console.ReadKey();
        }

        private static void DisplayResults(string parameters, List<double> results,
            ProbabilityFunction probabilityFunction, MathematicalExpectation mathematicalExpectation, Dispersion dispersion)
        {
            Console.WriteLine(Environment.NewLine +
                $"-----{dispersion.Method.Name.Replace("Dispersion", "")} distribution ({parameters})-----");
            results.Take(15).ToList().ForEach(x => Console.Write($"{x:F2} "));
            Console.Write(Environment.NewLine + $"{N} items: ");
            for (int i = -5; i < 5; i++)
            {
                Console.Write($"{i}({results.Count(x => x >= i && x <= i + 1)})");
            }
            Console.WriteLine("5");
            Console.WriteLine($"Practical  : Average={results.Average():F2}, Dispersion={CalculateDispersion(results):F2}");
            Console.WriteLine($"Theoretical: Average={mathematicalExpectation():F2}, Dispersion={dispersion():F2}");
            CheckPearsonCriteria(GetSortedList(results), probabilityFunction);

            double CalculateDispersion(List<double> list) => list.Sum(x => Math.Pow(x - list.Average(), 2)) / list.Count;
            List<double> GetSortedList(List<double> list) => list.OrderBy(x => x).ToList();
        }

        private static void CheckPearsonCriteria(List<double> list, ProbabilityFunction function)
        {
            var probabilityFunctionValues = GetProbabilityFunctionValues();
            var valuesAmount = GetAmountByValues();
            double value = 0;
            for (int i = 0; i < 50; i++)
            {
                if (probabilityFunctionValues[i] != 0)
                {
                    value += Math.Pow(valuesAmount[i] - N * probabilityFunctionValues[i], 2) / (N * probabilityFunctionValues[i]);
                }
            }
            Console.WriteLine($"Pearson criterion: {DisplayCriteriaResults(66.339)}");

            List<double> GetProbabilityFunctionValues() //For Puasson: 0.220, 0.333, 0.252, 0.127, 0.048, 0.015, 0.005
            {
                return GetIEnumerableProbabilityFunctionValues().ToList();
                IEnumerable<double> GetIEnumerableProbabilityFunctionValues()
                {
                    for (double i = 0; i < 10; i += 0.2)
                    {
                        yield return function(i + 0.1) * 0.2;
                    }
                }
            }
            List<int> GetAmountByValues()
            {
                return GetIEnumerableAmountByValues().ToList();
                IEnumerable<int> GetIEnumerableAmountByValues()
                {
                    for (double i = 0; i < 10; i += 0.2)
                    {
                        yield return list.Count(x => x >= i && x < i + 0.2);
                    }
                }
            }
            string DisplayCriteriaResults(double quantile) => value < quantile ?
                $"{value:F2} < {quantile:F2}, so it's passed" : $"{value:F2} > {quantile:F2}, so it isn't passed";
        }

        #region Sequence modeling algorithms

        private static List<double> GetNormalSequence(double m, double s2) => 
            GetStandartNormalSequence().Select(x => m + Math.Sqrt(s2) * x).ToList();

        private static List<double> GetLognormalSequence(double m, double s2) => 
            GetStandartNormalSequence().Select(x => m * Math.Exp(x * Math.Sqrt(s2))).ToList();

        private static List<double> GetCauchySequence(double x0, double gamma) => 
            GetRandomSequence(N).Select(x => x0 + gamma * Math.Tan(Math.PI * (x - 0.5))).ToList();

        private static List<double> GetUniformSequence(double a, double b) => 
            GetRandomSequence(N).Select(x => a + (b - a) * x).ToList();

        private static List<double> GetWeibullGnedenkoSequence(double lambda, double k) => 
            GetRandomSequence(N).Select(x => Math.Pow(-Math.Log(x) / lambda, 1 / k)).ToList();

        private static List<double> GetLogisticSequence(double mu, double s) => 
            GetRandomSequence(N).Select(x => mu + s * Math.Log(x / (1 - x))).ToList();

        private static List<double> GetStandartNormalSequence()
        {
            return GetStandartNormalSequence().ToList();
            IEnumerable<double> GetStandartNormalSequence()
            {
                int generationalN = 12;
                var randomSequence = GetRandomSequence(N * generationalN);
                for (int i = 0; i < N; i++)
                {
                    var randomSubsequence = randomSequence.Skip(i * generationalN).Take(generationalN).ToList();
                    yield return randomSubsequence.Sum() - (generationalN / 2);
                }
            }
        }

        #endregion

        #region Probability functions

        delegate double ProbabilityFunction(double x);

        private static double NormalProbabilityFunction(double x) => 
            Math.Exp(-Math.Pow(x - NormalM, 2)/(2 * NormalS2)) / Math.Sqrt(2 * Math.PI * NormalS2);

        private static double LognormalProbabilityFunction(double x) => 
            Math.Exp(-Math.Pow(Math.Log(x) / LognormalM, 2) / (2 * LognormalS2)) 
            / (x * Math.Sqrt(2 * Math.PI * LognormalS2));

        private static double CauchyProbabilityFunction(double x) => 
            CauchyGamma / (Math.PI * (Math.Pow(x - CauchyX0, 2) + Math.Pow(CauchyGamma, 2)));

        private static double UniformProbabilityFunction(double x) => 1 / (UniformB - UniformA);

        private static double WeibullGnedenkoProbabilityFunction(double x) => (WeibullGnedenkoK / WeibullGnedenkoLambda)
            * Math.Pow(x / WeibullGnedenkoLambda, WeibullGnedenkoK - 1) 
            * Math.Exp(-Math.Pow(x / WeibullGnedenkoLambda, WeibullGnedenkoK));

        private static double LogisticProbabilityFunction(double x) => Math.Exp((LogisticMu - x) / LogisticS) 
            / (LogisticS * Math.Pow(1 + Math.Exp((LogisticMu - x) / LogisticS), 2));

        #endregion

        #region Mathematical expectations

        delegate double MathematicalExpectation();

        private static double NormalMathematicalExpectation() => NormalM;

        private static double LognormalMathematicalExpectation() => Math.Exp(LognormalM + LognormalS2 / 2);

        private static double CauchyMathematicalExpectation() => Double.NaN;

        private static double UniformMathematicalExpectation() => (UniformA + UniformB) / 2;

        private static double WeibullGnedenkoMathematicalExpectation() => 
            WeibullGnedenkoLambda * Factorial((long)(1 / WeibullGnedenkoK));

        private static double LogisticMathematicalExpectation() => LogisticMu;

        #endregion

        #region Dispersions

        delegate double Dispersion();

        private static double NormalDispersion() => NormalS2;

        private static double LognormalDispersion() => (Math.Exp(LognormalS2) - 1) * Math.Exp(2 * LognormalM + LognormalS2);

        private static double CauchyDispersion() => Double.PositiveInfinity;

        private static double UniformDispersion() => Math.Pow(UniformB - UniformA, 2) / 12;

        private static double WeibullGnedenkoDispersion() => 
            Math.Pow(WeibullGnedenkoLambda, 2) * Factorial((long)(2 / WeibullGnedenkoK));

        private static double LogisticDispersion() => Math.Pow(Math.PI * LogisticS, 2) / 3;

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

