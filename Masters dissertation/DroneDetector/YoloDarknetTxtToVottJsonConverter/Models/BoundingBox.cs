using Newtonsoft.Json;
using System;

namespace YoloDarknetTxtToVottJsonConverter.Models
{
    public class BoundingBox
    {
        public BoundingBox(string[] yoloBoundingBoxValues, Size imageSize)
        {
            var centerLeft = Convert.ToDouble(yoloBoundingBoxValues[1]) * imageSize.Width;
            var centerTop = Convert.ToDouble(yoloBoundingBoxValues[2]) * imageSize.Height;
            var width = Convert.ToDouble(yoloBoundingBoxValues[3]) * imageSize.Width;
            var height = Convert.ToDouble(yoloBoundingBoxValues[4]) * imageSize.Height;

            var left = centerLeft - width / 2;
            var top = centerTop - height / 2;

            Left = Math.Round(left, 1);
            Top = Math.Round(top, 1);
            Width = Math.Round(width, 1);
            Height = Math.Round(height, 1);
        }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("left")]
        public double Left { get; set; }

        [JsonProperty("top")]
        public double Top { get; set; }
    }
}
