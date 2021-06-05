using System.IO;
using System.Text;
using YoloDarknetTxtToVottJsonConverter.Models;

namespace YoloDarknetTxtToVottJsonConverter
{
    public static class Converter
    {
        public static VottObject Convert(string imagePath)
        {
            var yoloTxtFilePath = Path.ChangeExtension(imagePath, ".txt");
            var vottObject = new VottObject(imagePath);

            using (var streamReader = new StreamReader(yoloTxtFilePath, Encoding.Default))
            {
                string yoloBoundingBoxLine;
                while ((yoloBoundingBoxLine = streamReader.ReadLine()) != null)
                {
                    var imageSize = vottObject.Asset.Size;
                    var region = new Region(yoloBoundingBoxLine, imageSize);
                    vottObject.Regions.Add(region);
                }
            }

            return vottObject;
        }
    }
}
