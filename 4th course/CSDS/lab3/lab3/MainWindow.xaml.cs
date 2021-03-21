using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows;

namespace lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void CalculateSHA1_Click(object sender, RoutedEventArgs ev)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var bytes = File.ReadAllBytes(openFileDialog.FileName).ToList();
                bytes = FillFinishBytes(bytes);
                uint h0 = 0x67452301, h1 = 0xEFCDAB89, h2 = 0x98BADCFE, h3 = 0x10325476, h4 = 0xC3D2E1F0;
                for (int i = 0; i < bytes.Count / 64; i++)
                {
                    var batch = bytes.Skip(64 * i).Take(64);
                    var w = new List<uint>();
                    for (int j = 0; j < 16; j++)
                    {
                        var fourBytes = batch.Skip(4 * j).Take(4).Reverse().ToArray();
                        w.Add(BitConverter.ToUInt32(fourBytes, 0));
                    }
                    for (int j = 16; j < 80; j++)
                    {
                        w.Add(GetCyclicShift(w[j - 3] ^ w[j - 8] ^ w[j - 14] ^ w[j - 16], 1));
                    }
                    uint a = h0, b = h1, c = h2, d = h3, e = h4, f = 0, k = 0, temp;
                    for (int j = 0; j < 80; j++)
                    {
                        if (j < 20)
                        {
                            f = (b & c) | ((~b) & d);
                            k = 0x5A827999;
                        }
                        else if (j < 40)
                        {
                            f = b ^ c ^ d;
                            k = 0x6ED9EBA1;
                        }
                        else if (j < 60)
                        {
                            f = (b & c) | (b & d) | (c & d);
                            k = 0x8F1BBCDC;
                        }
                        else 
                        {
                            f = b ^ c ^ d;
                            k = 0xCA62C1D6;
                        }

                        temp = GetCyclicShift(a, 5) + f + e + k + w[j];
                        e = d;
                        d = c;
                        c = GetCyclicShift(b, 30);
                        b = a;
                        a = temp;
                    }

                    h0 += a;
                    h1 += b;
                    h2 += c;
                    h3 += d;
                    h4 += e;
                }

                List<byte> result = BitConverter.GetBytes(h0).ToList();
                result.AddRange(BitConverter.GetBytes(h1).ToList());
                result.AddRange(BitConverter.GetBytes(h2).ToList());
                result.AddRange(BitConverter.GetBytes(h3).ToList());
                result.AddRange(BitConverter.GetBytes(h4).ToList());

                string path = Path.Combine(Path.GetDirectoryName(openFileDialog.FileName), "SHA-1 results.txt");
                File.AppendAllText(path, openFileDialog.SafeFileName + " - " + DateTime.Now + " - " + 
                    BitConverter.ToString(result.ToArray()).Replace("-", String.Empty) + Environment.NewLine);
            }
        }

        private List<byte> FillFinishBytes(List<byte> bytes)
        {
            var lengthInBytes = BitConverter.GetBytes((long)bytes.Count()).Reverse();
            var additionalBits = GetAdditionalBits(bytes.Count() % 64);
            bytes.AddRange(additionalBits);
            bytes.AddRange(lengthInBytes);
            return bytes;
        }

        private List<byte> GetAdditionalBits(int lastFragmentBytesAmount)
        {
            byte firstByte = BitConverter.GetBytes(128).First(); //1000 0000
            byte zeroByte = BitConverter.GetBytes(0).First();    //0000 0000
            List<byte> result = new List<byte>();
            if (lastFragmentBytesAmount < 56)
            {
                result.Add(firstByte);
                result.AddRange(Enumerable.Repeat(zeroByte, 55 - lastFragmentBytesAmount));
            }
            else if (lastFragmentBytesAmount > 56)
            {
                result.Add(firstByte);
                result.AddRange(Enumerable.Repeat(zeroByte, 119 - lastFragmentBytesAmount));
            }

            return result;
        }

        private uint GetCyclicShift(uint x, int shift)
        {
            BitArray bits = new BitArray(BitConverter.GetBytes(x));
            List<int> b = new List<int>();
            for (int i = 0; i < 32; i++)
            {
                b.Add(bits.Get(i) ? 1 : 0);
            }

            List<int> resultList = new List<int>();
            for (int i = 0; i < 32 - shift; i++)
            {
                resultList.Add(b[i + shift]);
            }
            for (int i = 0; i < shift; i++)
            {
                resultList.Add(b[i]);
            }

            uint result = 0;
            for (int i = 0; i < 32; i++)
            {
                result += (uint)resultList[i] * (uint)Math.Pow(2, 31 - i);
            }

            return result;
        }

        private void CheckEDC_Click(object sender, RoutedEventArgs ev)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var bytes = File.ReadAllBytes(openFileDialog.FileName).ToList();
                bytes = FillFinishBytes(bytes);
                uint h0 = 0x67452301, h1 = 0xEFCDAB89, h2 = 0x98BADCFE, h3 = 0x10325476, h4 = 0xC3D2E1F0;
                for (int i = 0; i < bytes.Count / 64; i++)
                {
                    var batch = bytes.Skip(64 * i).Take(64);
                    var w = new List<uint>();
                    for (int j = 0; j < 16; j++)
                    {
                        var fourBytes = batch.Skip(4 * j).Take(4).Reverse().ToArray();
                        w.Add(BitConverter.ToUInt32(fourBytes, 0));
                    }
                    for (int j = 16; j < 80; j++)
                    {
                        w.Add(GetCyclicShift(w[j - 3] ^ w[j - 8] ^ w[j - 14] ^ w[j - 16], 1));
                    }
                    uint a = h0, b = h1, c = h2, d = h3, e = h4, f = 0, k = 0, temp;
                    for (int j = 0; j < 80; j++)
                    {
                        if (j < 20)
                        {
                            f = (b & c) | ((~b) & d);
                            k = 0x5A827999;
                        }
                        else if (j < 40)
                        {
                            f = b ^ c ^ d;
                            k = 0x6ED9EBA1;
                        }
                        else if (j < 60)
                        {
                            f = (b & c) | (b & d) | (c & d);
                            k = 0x8F1BBCDC;
                        }
                        else
                        {
                            f = b ^ c ^ d;
                            k = 0xCA62C1D6;
                        }

                        temp = GetCyclicShift(a, 5) + f + e + k + w[j];
                        e = d;
                        d = c;
                        c = GetCyclicShift(b, 30);
                        b = a;
                        a = temp;
                    }

                    h0 += a;
                    h1 += b;
                    h2 += c;
                    h3 += d;
                    h4 += e;
                }

                List<byte> result = BitConverter.GetBytes(h0).ToList();
                result.AddRange(BitConverter.GetBytes(h1).ToList());
                result.AddRange(BitConverter.GetBytes(h2).ToList());
                result.AddRange(BitConverter.GetBytes(h3).ToList());
                result.AddRange(BitConverter.GetBytes(h4).ToList());

                BigInteger hash = new BigInteger(result.ToArray());
                string rsa = Rsa.Generate();
                string[] rsaValues = rsa.Split(',');
                BigInteger openExponent = BigInteger.Parse(rsaValues[0]);
                BigInteger privateExponent = BigInteger.Parse(rsaValues[1]);
                BigInteger n = BigInteger.Parse(rsaValues[2]);
                Rsa rsaObj = new Rsa(hash);
                BigInteger edc = Rsa.ModPow(hash, privateExponent, n);
                BigInteger decryptedHash = Rsa.PowMod(edc, openExponent, n);
                bool allIsOK = hash == decryptedHash;
                MessageBox.Show($"EDC is equal to {edc},\n       hash={hash},\n decrHash = {decryptedHash}.\n All Is OK? {allIsOK}.", "Info", MessageBoxButton.OK);
            }
        }

        private void EllipticCurve_Click(object sender, RoutedEventArgs e)
        {
            int M = 67, a = 2, b = 3; //E67(2, 3) => y2 = x3 + 2x + 3 mod 67 => (x, y) = (1, 6)
            int gx = 1, gy = 6;
            int secretA = 31, secretB = 37;
            Point openA = ModPoint(new Point(gx, gy), secretA);
            Point openB = ModPoint(new Point(gx, gy), secretB);
            Point kA = ModPoint(openB, secretA);
            Point kB = ModPoint(openA, secretB);
            MessageBox.Show($"kA = {kA}\nkB = {kB}", "Info", MessageBoxButton.OK);
        }

        private Point ModPoint(Point point, int power)
        {
            Point result = point;
            for (int i = 0; i < power - 1; i++)
            {
                result = SumPoints(result, point);
            }

            return result;
        }

        private Point SumPoints(Point p, Point q)
        {
            double alpha = (q.Y == p.Y || q.X == p.X) ? 1 : (q.Y - p.Y) / (q.X - p.X);
            double resultX = alpha * alpha - p.X - p.Y;
            double resultY = -p.Y + alpha * (p.X - q.X);
            return new Point(-resultX, -resultY);
        }
    }
}
