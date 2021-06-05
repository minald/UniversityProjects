using Newtonsoft.Json;
using System.Collections.Generic;

namespace YoloDarknetTxtToVottJsonConverter.Models
{
    internal class VottMainObject
    {
        [JsonProperty("assets")]
        public Dictionary<string, VottObject> Assets { get; set; } = new Dictionary<string, VottObject>();
    }
}
