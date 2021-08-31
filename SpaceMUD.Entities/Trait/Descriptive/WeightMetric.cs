using SpaceMUD.Entities.Trait.Descriptive.Base.IDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Data.Measurements;

namespace SpaceMUD.Entities.Trait.Descriptive
{
    public class WeightMetric : IWeight
    {
        public string Weight { get; private set; }

        public MeasurementUnit Unit => MeasurementUnit.Metric;

        public WeightMetric(string weight) { Weight = weight; }
    }
}
