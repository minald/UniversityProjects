// This file was auto-generated by ML.NET Model Builder. 

using System;
using SecondDetectionModel;

namespace SecondDetectionModel.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = new ModelInput()
            {
                ImageSource = @"C:\Users\Andrey\Downloads\aerial-cars-dataset-master\DJI-00760-00001.jpg",
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine($"ImageSource: {sampleData.ImageSource}");
            Console.WriteLine("\n\nPredicted Boxes:\n");
            Console.WriteLine(predictionResult);
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}