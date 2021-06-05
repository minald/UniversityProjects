using Microsoft.ML.Data;

namespace FirstDetectionModel
{
    public class TinyYoloPrediction : IOnnxObjectPrediction
    {
        [ColumnName("grid")]
        public float[] PredictedLabels { get; set; }
    }
}
