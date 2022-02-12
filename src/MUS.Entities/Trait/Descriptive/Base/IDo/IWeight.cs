using MUS.Common.Enums.Data.Measurements;

namespace MUS.Entities.Trait.Descriptive.Base.IDo
{
    public interface IWeight
    {
        string Weight { get; }
        MeasurementUnit Unit { get; }
    }
}
