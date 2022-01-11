using MUS.Entities.Base;

namespace MUS.Entities.Trait.Functional.Base.IDo
{
    public interface IDoBePickedUp
    {
        GameObject PickUp();
        bool IsPickedUp { get; }
    }
}
