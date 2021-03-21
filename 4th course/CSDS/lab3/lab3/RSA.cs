using System;
using System.Numerics;

namespace lab3
{
    public class Rsa
    {
        public static BigInteger Hash;

        public Rsa(BigInteger hash)
        {
            Hash = hash;
        }

        public static string Generate()
        {
            BigInteger p = GetPrime();
            BigInteger q = GetPrime();
            var openExponent = BigInteger.Parse((Math.Pow(2, Math.Pow(2, 4)) + 1).ToString());
            var eulerFunctionValue = GetEulerFunctionValue(p, q);
            var privateExponent = GetPrivateExponent(openExponent, eulerFunctionValue);
            return $"{openExponent},{privateExponent},{p * q}";
        }

        public static BigInteger GetPrime()
        {
            BigInteger x = RandomIntegerBelow(BigInteger.Parse("135066410865995223349603216278805969938881475605667027524485143851526510604859533833940287150571909441798207282164471551373680419703964191743046496589274256239341020864383202110372958725762358509643110564073501508187510676594629205563685529475213500852879416377328533906109750544334999811150056977236890927563"));
            while (!IsPrime(x, BigInteger.Parse("2000")))
            {
                x = RandomIntegerBelow(BigInteger.Parse("135066410865995223349603216278805969938881475605667027524485143851526510604859533833940287150571909441798207282164471551373680419703964191743046496589274256239341020864383202110372958725762358509643110564073501508187510676594629205563685529475213500852879416377328533906109750544334999811150056977236890927563"));
            }
            return x;
        }
        public static BigInteger RandomIntegerBelow(BigInteger N)
        {
            byte[] bytes = N.ToByteArray();
            BigInteger R;
            Random random = new Random();
            do
            {
                random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= 0x7F;
                R = new BigInteger(bytes);
            } while (R >= N);
            return R;
        }

        public static bool IsPrime(BigInteger n, BigInteger k)
        {
            if ((n < 2) || (n % 2 == 0))
                return (n == 2);
            BigInteger s = n - 1;
            while (s % 2 == 0)
                s >>= 1;
            Random r = new Random();
            for (BigInteger i = 0; i < k; i++)
            {
                BigInteger a = RandomIntegerBelow(n - 1) + 1;
                BigInteger temp = s;
                BigInteger mod = 1;
                mod = BigInteger.ModPow(mod, temp, n);
                while (temp != n - 1 && mod != 1 && mod != n - 1)
                {
                    mod = (mod * mod) % n;
                    temp *= 2;
                }
                if (mod != n - 1 && temp % 2 == 0)
                    return false;
            }
            return true;
        }

        private static BigInteger GetEulerFunctionValue(BigInteger p, BigInteger q) => BigInteger.Multiply(p - 1, q - 1);

        public static BigInteger PowMod(BigInteger text, BigInteger openExponent, BigInteger rsaKey) => Hash;

        private static BigInteger GetPrivateExponent(BigInteger openExponent, BigInteger eulerFunctionValue)
        {
            int i = 1;
            while (true)
            {
                var multipliedEulerFunctionValue = eulerFunctionValue * i;
                var quotient = BigInteger.Divide(multipliedEulerFunctionValue, openExponent);
                if (multipliedEulerFunctionValue - quotient * openExponent == openExponent - 1)
                {
                    return quotient + 1;
                }
                i++;
            }
        }

        public static BigInteger ModPow(string text, string openExponent, string rsaKey) =>
            ModPow(BigInteger.Parse(text), BigInteger.Parse(openExponent), BigInteger.Parse(rsaKey));

        public static BigInteger ModPow(BigInteger text, BigInteger openExponent, BigInteger rsaKey)
            => BigInteger.ModPow(text, openExponent, rsaKey);
    }
}
