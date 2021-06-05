using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace YoloDarknetTxtToVottJsonConverter.Models
{
    public class VottObject
    {
        public VottObject(string imagePath)
        {
            Asset = new Asset()
            {
                Format = Path.GetExtension(imagePath).Trim('.'),
                Id = Guid.NewGuid().ToString("N"),
                Name = Path.GetFileName(imagePath),
                Path = $"file:" + imagePath,
                Size = GetImageSize(imagePath),
                State = 2,
                Type = 1
            };

            Regions = new List<Region>();
            Version = "2.2.0";
        }

        [JsonProperty("asset")]
        public Asset Asset { get; set; }

        [JsonProperty("regions")]
        public List<Region> Regions { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        private Size GetImageSize(string imagePath)
        {
            var image = new System.Drawing.Bitmap(imagePath);
            return new Size()
            {
                Width = image.Width,
                Height = image.Height
            };
        }
    }
}
