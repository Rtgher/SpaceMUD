using MUS.Common.Enums.Data.Measurements;
using MUS.Entities.Trait.Descriptive.Base.IDo;

namespace MUS.Entities.Trait.Descriptive
{
    public class WeightMetric : IWeight
    {
        public string Weight { get; private set; }

        public MeasurementUnit Unit => MeasurementUnit.Metric;

        public WeightMetric(string weight) { Weight = weight; }
    }
}
