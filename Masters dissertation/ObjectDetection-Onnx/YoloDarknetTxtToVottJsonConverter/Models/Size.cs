using Newtonsoft.Json;

namespace YoloDarknetTxtToVottJsonConverter.Models
{
    public class Size
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
