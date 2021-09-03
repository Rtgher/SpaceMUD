using SpaceMUD.Common.Tools.Attributes.Parser;
using SpaceMUD.Entities.Trait.Descriptive.Base.IDo;
using SpaceMUD.Entities.Trait.Descriptive.Base.IHave;
using SpaceMUD.Entities.Trait.Functional.Base.ICan;
using SpaceMUD.Entities.Trait.Functional.Base.IDo;

namespace SpaceMUD.Entities.Base.Actor
{
    [Noun(Common.Enums.Data.Functional.TargetType.Actor, "Actor", "Person", "Character", "Char", "C")]
    public class BaseActor : GameObject, IHaveHeight, ICanBePickedUpIfImDead
    {
        public IHeight Height { get; private set; }
        public IWeight Weight { get; private set; }
        public IDoDie DoDie { get; private set; }
        public IDoBePickedUp DoCanBePickedUp { get; private set; }

        public BaseActor(IDoDie die, IHeight height, IWeight weight) { DoDie = die; Height = height; Weight = weight; }
    }
}
