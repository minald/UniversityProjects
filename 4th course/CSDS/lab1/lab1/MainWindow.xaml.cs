using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int LettersInAlphabet = 26;
        public const int A_IndexInASCII = 65;
        public const int Z_IndexInASCII = 90;
        public const int a_IndexInASCII = 97;
        public const int z_IndexInASCII = 122;
        public const int LongestWordLength = 20;

        public Dictionary<char, double> EnglishFrequencies = new Dictionary<char, double>()
        {
            { 'a', 0.08167 },
            { 'b', 0.01492 },
            { 'c', 0.02782 },
            { 'd', 0.04253 },
            { 'e', 0.12702 },
            { 'f', 0.0228 },
            { 'g', 0.02015 },
            { 'h', 0.06094 },
            { 'i', 0.06966 },
            { 'j', 0.00153 },
            { 'k', 0.00772 },
            { 'l', 0.04025 },
            { 'm', 0.02406 },
            { 'n', 0.06749 },
            { 'o', 0.07507 },
            { 'p', 0.01929 },
            { 'q', 0.00095 },
            { 'r', 0.05987 },
            { 's', 0.06327 },
            { 't', 0.09056 },
            { 'u', 0.02758 },
            { 'v', 0.00978 },
            { 'w', 0.0236 },
            { 'x', 0.0015 },
            { 'y', 0.01974 },
            { 'z', 0.00074 }
        };

        public string Text { get; set; }

        public string CurrentFileName { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                CurrentFileName = openFileDialog.FileName;
                Text = File.ReadAllText(CurrentFileName);
            }
        }

        private void EncodeCeasar_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(AddStringToFileName(CurrentFileName, $"_Ceasar({Shift.Text})"), 
                GetCeasarEncodedText(Text, Convert.ToInt32(Shift.Text) % LettersInAlphabet));
        }

        private void EncodeVigenere_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(AddStringToFileName(CurrentFileName, $"_Vigenere({SecretWord.Text})"),
                GetVigenereEncodedText(Text, SecretWord.Text.ToLower()));
        }

        private void DecodeVigenere_Click(object sender, RoutedEventArgs e)
        {
            int secretWordLength = GetSecretWordLength();
            var subgroups = new List<List<char>>();
            for (int i = 0; i < secretWordLength; i++)
            {
                subgroups.Add(new List<char>());
            }
            string trimmedText = GetTrimmedText();
            for (int i = 0; i < trimmedText.Length; i++)
            {
                subgroups[i % secretWordLength].Add(trimmedText[i]);
            }

            var keys = new List<int>(secretWordLength);
            foreach (var subgroup in subgroups)
            {
                var frequencies = GetСharacterFrequencies(subgroup);
                var minPearsonCriteriaValue = GetPearsonCriteriaValue(frequencies, EnglishFrequencies.Select(x => x.Value).ToList());
            }

            var builder = new StringBuilder();
            string secretWord = GetSecretWord(secretWordLength);
            var secretWordBytes = Encoding.ASCII.GetBytes(secretWord);
            int secretWordIndex = 0;
            foreach (var c in Encoding.ASCII.GetBytes(Text))
            {
                if (Char.IsLetter((char)c))
                {
                    builder.Append(GetCeasarEncodedChar(c, a_IndexInASCII - secretWordBytes[secretWordIndex]));
                    secretWordIndex = (secretWordIndex == secretWord.Length - 1) ? 0 : secretWordIndex + 1;
                }
                else
                {
                    builder.Append((char)c);
                }
            }
            File.WriteAllText(AddStringToFileName(CurrentFileName, $"_Decoded"), builder.ToString());
        }

        private List<double> GetСharacterFrequencies(List<char> chars)
        {
            var amounts = Enumerable.Repeat(0, 26).ToList();
            chars.ForEach(x => amounts[x - a_IndexInASCII]++);
            return amounts.Select(x => (double)x / chars.Count).ToList();
        }

        private string AddStringToFileName(string fileName, string line) =>
            Path.Combine(Path.GetDirectoryName(fileName), 
                Path.GetFileNameWithoutExtension(fileName) + line + Path.GetExtension(fileName));

        private string GetCeasarEncodedText(string text, int shift)
        {
            var builder = new StringBuilder();
            foreach (var c in Encoding.ASCII.GetBytes(text))
            {
                builder.Append(GetCeasarEncodedChar(c, shift));
            }

            return builder.ToString();
        }

        private string GetVigenereEncodedText(string text, string secretWord)
        {
            var builder = new StringBuilder();
            var secretWordBytes = Encoding.ASCII.GetBytes(secretWord);
            int secretWordIndex = 0;
            foreach (var c in Encoding.ASCII.GetBytes(text))
            {
                if (Char.IsLetter((char)c))
                {
                    builder.Append(GetCeasarEncodedChar(c, secretWordBytes[secretWordIndex] - a_IndexInASCII));
                    secretWordIndex = (secretWordIndex == secretWord.Length - 1) ? 0 : secretWordIndex + 1;
                }
                else
                {
                    builder.Append((char)c);
                }
            }

            return builder.ToString();
        }

        private char GetCeasarEncodedChar(byte c, int shift)
        {
            if (c >= A_IndexInASCII && c <= Z_IndexInASCII)
            {
                return (char)(A_IndexInASCII + ((c - A_IndexInASCII + shift + LettersInAlphabet) % LettersInAlphabet));
            }
            else if (c >= a_IndexInASCII && c <= z_IndexInASCII)
            {
                return (char)(a_IndexInASCII + ((c - a_IndexInASCII + shift + LettersInAlphabet) % LettersInAlphabet));
            }
            else
            {
                return (char)c;
            }
        }

        private int GetSecretWordLength()
        {
            string trimmedText = GetTrimmedText();
            var words = new List<Word>();
            for (int wordLength = 2; wordLength < 5; wordLength++)
            {
                for (int i = 0; i <= trimmedText.Length - i; i++)
                {
                    string word = trimmedText.Substring(i, wordLength);
                    var currentWord = words.FirstOrDefault(x => x.Name == word);
                    if (currentWord == null)
                    {
                        words.Add(new Word(word, i));
                    }
                    else
                    {
                        currentWord.AddEntryIndex(i);
                    }
                }
            }

            var frequentWords = words.Where(x => x.EntryIndexes.Count > 5).OrderBy(x => x.GetMostFrequentDistance());
            return frequentWords.Max(x => x.GetMostFrequentDistance());
        }

        private string GetSecretWord(int length)
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            return letters.Substring(0, length);
        }

        private string GetTrimmedText() => Regex.Replace(Text, "[^A-Za-z]", String.Empty).ToLower();

        private double GetPearsonCriteriaValue(List<double> practical, List<double> real)
        {
            double value = 0;
            for (int i = 0; i < 26; i++)
            {
                value += Math.Pow(practical[i] - real[i], 2) / real[i];
            }
            return value;
        }

        private class Word
        {
            public string Name { get; set; }

            public List<int> EntryIndexes { get; set; } = new List<int>();

            public Word(string name, int firstEntryIndex)
            {
                Name = name;
                EntryIndexes.Add(firstEntryIndex);
            }

            public void AddEntryIndex(int newEntryIndex) => EntryIndexes.Add(newEntryIndex);

            public int GetMostFrequentDistance()
            {
                var distances = GetDistances();
                int mostFrequentDistance = 1;
                int mostFrequentDistanceAmount = 0;
                for (int wordLength = 2; wordLength < LongestWordLength; wordLength++)
                {
                    int amount = distances.Count(x => x % wordLength == 0);
                    if (amount > mostFrequentDistanceAmount)
                    {
                        mostFrequentDistanceAmount = amount;
                        mostFrequentDistance = wordLength;
                    }
                }

                return mostFrequentDistance;
            }

            private IEnumerable<int> GetDistances()
            {
                for (int i = 1; i < EntryIndexes.Count; i++)
                {
                    yield return EntryIndexes[i] - EntryIndexes[i - 1];
                }
            }
        }
    }
}
