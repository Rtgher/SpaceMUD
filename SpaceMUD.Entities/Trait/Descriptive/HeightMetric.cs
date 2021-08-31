using SpaceMUD.Entities.Trait.Descriptive.Base.IDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Data.Measurements;

namespace SpaceMUD.Entities.Trait.Descriptive
{
    public class HeightMetric : IHeight
    {
        public string Height { get; private set; }

        public MeasurementUnit Unit => MeasurementUnit.Metric;

        private double _valueInCm;

        public HeightMetric(string height) { Height = height; }
    }
}
