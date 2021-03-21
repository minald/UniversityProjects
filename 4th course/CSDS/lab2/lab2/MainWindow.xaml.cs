using Microsoft.Win32;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly string CurrentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public readonly string ServerSessionKeysPath = Path.Combine(CurrentDirectory, "Server_SessionKey.txt");
        public readonly string ClientEncryptedSessionKeysPath = Path.Combine(CurrentDirectory, "Client_EncryptedSessionKey.txt");
        public readonly string ClientDecryptedSessionKeysPath = Path.Combine(CurrentDirectory, "Client_DecryptedSessionKey.txt");
        public readonly string OpenRsaParametersPath = Path.Combine(CurrentDirectory, "RSA.txt");
        public readonly string ClientPrivateExponentPath = Path.Combine(CurrentDirectory, "Client_RSA.txt");

        public static Logger Logger = LogManager.GetCurrentClassLogger();

        public const uint Phi = 0x9e3779b9;

        public byte[] Bytes { get; set; }

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
                Logger.Info("File has been selected: " + CurrentFileName);
                Bytes = File.ReadAllBytes(CurrentFileName);
                FileNameTB.Text = openFileDialog.SafeFileName;
            }
        }

        private void GenerateRSA_Click(object sender, RoutedEventArgs e)
            => File.WriteAllText(Path.Combine(CurrentDirectory, "MyRSA.txt"), Rsa.Generate());

        private void GenerateSessionKey_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("Starting session key generation...");
            var random = new Random();
            var list = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                var randomInt = random.Next().ToString();
                list.Add(randomInt);
                Logger.Info("32 bytes has been generated: " + randomInt);
            }
            File.WriteAllText(ServerSessionKeysPath, String.Join(",", list));
            Logger.Info("Finishing session key generation ...");
        }

        private void SendEncryptedSessionKeyToClient_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("Starting session keys encrypting ...");
            var sessionKeys = File.ReadAllText(ServerSessionKeysPath).Split(',').ToList();
            var openRsaParameters = File.ReadAllText(OpenRsaParametersPath).Split(',');
            var encryptedSessionKeys = sessionKeys.Select(x => Rsa.ModPow(x, openRsaParameters[0], openRsaParameters[1]));
            encryptedSessionKeys.ToList().ForEach(x => Logger.Info("32 bytes has been encrypted: " + x));
            File.WriteAllText(ClientEncryptedSessionKeysPath, String.Join(",", encryptedSessionKeys));
            Logger.Info("Finishing session keys encrypting ...");
        }

        private void DecryptSessionKey_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("Starting session keys decrypting ...");
            var encryptedSessionKeys = File.ReadAllText(ClientEncryptedSessionKeysPath).Split(',').ToList();
            var openRsaParameters = File.ReadAllText(OpenRsaParametersPath).Split(',');
            var privateExponent = File.ReadAllText(ClientPrivateExponentPath);
            var decryptedSessionKeys = encryptedSessionKeys.Select(x => Rsa.ModPow(x, privateExponent, openRsaParameters[1]));
            decryptedSessionKeys.ToList().ForEach(x => Logger.Info("32 bytes has been decrypted: " + x));
            File.WriteAllText(ClientDecryptedSessionKeysPath, String.Join(",", decryptedSessionKeys));
            Logger.Info("Finishing session keys decrypting ...");
        }

        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("Starting file encoding ...");
            var initialBits = new BitArray(Bytes);
            var bits = new BitArray(initialBits);
            for (int i = 0; i < 32; i++)
            {
                bits.Set(4 * i, initialBits[i]);
                bits.Set(4 * i + 1, initialBits[i + 32]);
                bits.Set(4 * i + 2, initialBits[i + 64]);
                bits.Set(4 * i + 3, initialBits[i + 96]);
            }
            var mainSubKeys = File.ReadAllText(ServerSessionKeysPath).Split(',').Select(x => Int32.Parse(x)).ToList();
            var subKeys = GetSubKeys(mainSubKeys).ToList();
            for (int i = 0; i <= 32; i++)
            {
                bits = bits.Xor(subKeys[i]);
            }
            var finalBits = new BitArray(bits);
            for (int i = 0; i < 32; i++)
            {
                finalBits.Set(i, bits[4 * i]);
                finalBits.Set(i + 32, bits[4 * i + 1]);
                finalBits.Set(i + 64, bits[4 * i + 2]);
                finalBits.Set(i + 96, bits[4 * i + 3]);
            }
            byte[] bytes = new byte[16];
            finalBits.CopyTo(bytes, 0);
            File.WriteAllBytes(AddStringToFileName(CurrentFileName, $"_Encoded"), bytes);
            Logger.Info("Finishing file encoding ...");
        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("Starting file decoding ...");
            var initialBits = new BitArray(Bytes);
            var bits = new BitArray(initialBits);
            for (int i = 0; i < 32; i++)
            {
                bits.Set(4 * i, initialBits[i]);
                bits.Set(4 * i + 1, initialBits[i + 32]);
                bits.Set(4 * i + 2, initialBits[i + 64]);
                bits.Set(4 * i + 3, initialBits[i + 96]);
            }
            var mainSubKeys = File.ReadAllText(ClientDecryptedSessionKeysPath).Split(',').Select(x => Int32.Parse(x)).ToList();
            var subKeys = GetSubKeys(mainSubKeys).ToList();
            for (int i = 32; i >= 0; i--)
            {
                bits = bits.Xor(subKeys[i]);
            }
            var finalBits = new BitArray(bits);
            for (int i = 0; i < 32; i++)
            {
                finalBits.Set(i, bits[4 * i]);
                finalBits.Set(i + 32, bits[4 * i + 1]);
                finalBits.Set(i + 64, bits[4 * i + 2]);
                finalBits.Set(i + 96, bits[4 * i + 3]);
            }

            byte[] bytes = new byte[16];
            finalBits.CopyTo(bytes, 0);
            File.WriteAllBytes(AddStringToFileName(CurrentFileName, $"_DecodedByClient"), bytes);
            Logger.Info("Finishing file decoding ...");
        }

        private IEnumerable<BitArray> GetSubKeys(List<int> mainSubKeys)
        {
            Logger.Info("Starting subkeys generation ...");
            var subKeys = new List<int>();
            subKeys.AddRange(mainSubKeys);
            for (int i = 8; i < 140; i++)
            {
                subKeys.Add(subKeys[i-8] ^ subKeys[i - 5] ^ subKeys[i - 3] ^ subKeys[i - 1] ^ unchecked((int)Phi) ^ i);
                Logger.Info($"Subkey {i - 8} has been generated: {subKeys.Last()}");
            }
            for (int i = 0; i < 33; i++)
            {
                yield return new BitArray(new int[] { subKeys[4 * i + 8], subKeys[4 * i + 9], subKeys[4 * i + 10], subKeys[4 * i + 11] });
            }
            Logger.Info("Finishing subkeys generation ...");
        }

        private string AddStringToFileName(string fileName, string line) =>
            Path.Combine(Path.GetDirectoryName(fileName),
                Path.GetFileNameWithoutExtension(fileName) + line + Path.GetExtension(fileName));
    }
}
