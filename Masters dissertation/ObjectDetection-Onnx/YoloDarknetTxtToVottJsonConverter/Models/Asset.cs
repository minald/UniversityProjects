using Newtonsoft.Json;

namespace YoloDarknetTxtToVottJsonConverter.Models
{
    public class Asset
    {
        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; } // JsonSerializer adds two slashes instead of one (like in the original VoTT json file) but it works

        [JsonProperty("size")]
        public Size Size { get; set; }

        [JsonProperty("state")]
        public int State { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }
}
