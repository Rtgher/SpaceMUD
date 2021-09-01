using SpaceMUD.Entities.Base;


namespace SpaceMUD.Entities.Trait.Functional.Base.IDo
{
    public interface IDoBePickedUp
    {
        GameObject PickUp();
        bool IsPickedUp { get; }
    }
}
