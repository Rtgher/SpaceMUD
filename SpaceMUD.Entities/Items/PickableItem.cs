using SpaceMUD.Entities.Base;
using SpaceMUD.Entities.Trait.Descriptive.Base.IDo;
using SpaceMUD.Entities.Trait.Functional.Base.ICan;
using SpaceMUD.Entities.Trait.Functional.Base.IDo;

namespace SpaceMUD.Entities.Items
{
    public class PickableItem : GameObject, ICanBePickedUp
    {
        public IDoBePickedUp DoCanBePickedUp { get; private set; }

        public IWeight Weight { get; private set; }
    }
}
