using SpaceMUD.Entities.Trait.Descriptive.Base.ICan;
using SpaceMUD.Entities.Trait.Descriptive.Base.IDo;
using SpaceMUD.Entities.Trait.Functional.Base.ICan;

namespace SpaceMUD.Entities.Base.Actor
{
    public class BaseActor : GameObject, IHaveHeight, ICanBePickedUp
    {
        public IHeight Height { get; private set; }
        public IWeight Weight { get; private set; }

        public BaseActor(IHeight height, IWeight weight) { Height = height; Weight = weight; }
    }
}
