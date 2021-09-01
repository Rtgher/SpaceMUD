using SpaceMUD.Entities.Base;
using SpaceMUD.Entities.Trait.Descriptive.Base.IHave;
using SpaceMUD.Entities.Trait.Functional.Base.IDo;

namespace SpaceMUD.Entities.Trait.Functional.Base.ICan
{
    public interface ICanBePickedUp : IHaveWeight
    {
        IDoBePickedUp DoCanBePickedUp { get; }
    }
}
