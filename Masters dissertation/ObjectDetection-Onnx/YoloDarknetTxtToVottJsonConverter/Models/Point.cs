using Newtonsoft.Json;

namespace YoloDarknetTxtToVottJsonConverter.Models
{
    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }
}
