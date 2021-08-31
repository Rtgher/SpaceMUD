using SpaceMUD.Common.Enums.Data.Measurements;


namespace SpaceMUD.Entities.Trait.Descriptive.Base.IDo
{
    public interface IHeight
    {
        string Height { get; }
        MeasurementUnit Unit { get; }
    }
}
