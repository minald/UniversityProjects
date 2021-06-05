using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YoloDarknetTxtToVottJsonConverter.Models
{
    public class Region
    {
        public Region(string yoloBoundingBoxLine, Size imageSize)
        {
            var yoloBoundingBoxValues = yoloBoundingBoxLine.Split();
            int tagIndex = Convert.ToInt32(yoloBoundingBoxValues[0]);
            var boundingBox = new BoundingBox(yoloBoundingBoxValues, imageSize);

            Id = GenerateRandomString(length: 9);
            Type = "RECTANGLE";
            Tags = new List<string>() { GetTagName(tagIndex) };
            BoundingBox = boundingBox;
            InitializePoints();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("boundingBox")]
        public BoundingBox BoundingBox { get; set; }

        [JsonProperty("points")]
        public List<Point> Points { get; set; }

        private string GenerateRandomString(int length)
        {
            var random = new Random();
            const string availableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
            var chars = Enumerable.Repeat(availableChars, length)
              .Select(str => str[random.Next(str.Length)]).ToArray();
            return new string(chars);
        }

        private string GetTagName(int index)
        {
            var tags = new Dictionary<int, string>()
            {
                { 0, "car" },
                { 1, "truck" },
                { 2, "bus" },
                { 3, "minibus" },
                { 4, "cyclist" }
            };

            return tags[index];
        }

        private void InitializePoints()
        {
            var left = BoundingBox.Left;
            var top = BoundingBox.Top;
            var right = BoundingBox.Left + BoundingBox.Width;
            var bottom = BoundingBox.Top + BoundingBox.Height;

            Points = new List<Point>() 
            { 
                new Point(left, top),
                new Point(right, top),
                new Point(right, bottom),
                new Point(left, bottom)
            };
        }
    }
}
