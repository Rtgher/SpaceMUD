using MUS.Common.Enums.Data.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUS.Entities.Trait.Descriptive.Base.IDo
{
    public interface IWeight
    {
        string Weight { get; }
        MeasurementUnit Unit { get; }
    }
}
