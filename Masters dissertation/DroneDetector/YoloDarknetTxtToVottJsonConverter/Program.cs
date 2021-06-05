using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YoloDarknetTxtToVottJsonConverter.Models;

namespace YoloDarknetTxtToVottJsonConverter
{
    public class Program
    {
        private static DirectoryInfo outputDirectory;

        static void Main(string[] args)
        {
            CreateOutputDirectory();
            var inputDirectoryInfo = new DirectoryInfo(@"C:\Users\Andrey\Downloads\aerial-cars-dataset-master");
            var images = GetImages(inputDirectoryInfo);

            var vottMainObject = new VottMainObject();
            var counter = 0;
            foreach (var image in images)
            {
                counter++;
                Console.WriteLine($"{image.Name} has been found! #{counter}.");
                var vottObject = Converter.Convert(image.FullName);
                vottMainObject.Assets.Add(vottObject.Asset.Id, vottObject);
                CreateOutputFile(vottObject);
                Console.WriteLine($"{image.Name} has been processed!");
            }

            CreateMainOutputFile(vottMainObject);
            Console.WriteLine($"Main output file has been created!");
        }

        private static IEnumerable<FileInfo> GetImages(DirectoryInfo directoryInfo)
        {
            var jpgImages = directoryInfo.GetFiles("*.jpg");
            var pngImages = directoryInfo.GetFiles("*.png");
            return jpgImages.Union(pngImages);
        }

        private static void CreateOutputDirectory()
        {
            var outputPath = @"C:\Users\Andrey\Downloads\YoloToVottOutput";

            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, recursive: true);
            }

            outputDirectory = Directory.CreateDirectory(outputPath);
            Console.WriteLine("The output directory has been created successfully.");
        }

        private static void CreateOutputFile(VottObject vottObject)
        {
            var outputFileName = $"{vottObject.Asset.Id}-asset.json";
            var outputFilePath = Path.Combine(outputDirectory.FullName, outputFileName);

            using var streamWriter = File.CreateText(outputFilePath);
            using var jsonTextWriter = new JsonTextWriter(streamWriter)
            {
                Formatting = Formatting.Indented,
                Indentation = 4
            };
            new JsonSerializer().Serialize(jsonTextWriter, vottObject);

            //string json = JsonConvert.SerializeObject(vottObject, Formatting.Indented)
            //    .Replace(@"\\", @"/"); // Fixing slashes escaping in the path
            //streamWriter.Write(json);
        }

        private static void CreateMainOutputFile(VottMainObject vottMainObject)
        {
            var outputFileName = "vottMainObject-export.json";
            var outputFilePath = Path.Combine(outputDirectory.FullName, outputFileName);

            using var streamWriter = File.CreateText(outputFilePath);
            using var jsonTextWriter = new JsonTextWriter(streamWriter)
            {
                Formatting = Formatting.Indented,
                Indentation = 4
            };
            new JsonSerializer().Serialize(jsonTextWriter, vottMainObject);
        }
    }
}
