using MUS.Entities.Trait.Descriptive.Base.IHave;
using MUS.Entities.Trait.Functional.Base.IDo;

namespace MUS.Entities.Trait.Functional.Base.ICan
{
    public interface ICanBePickedUp : IHaveWeight
    {
        IDoBePickedUp DoCanBePickedUp { get; }
    }
}
