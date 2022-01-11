using MUS.Common.Enums.Data.Measurements;


namespace MUS.Entities.Trait.Descriptive.Base.IDo
{
    public interface IHeight
    {
        string Height { get; }
        MeasurementUnit Unit { get; }
    }
}
