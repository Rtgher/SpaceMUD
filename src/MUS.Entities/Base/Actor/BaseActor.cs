using MUS.Common.Tools.Attributes.Parser;
using MUS.Entities.Trait.Descriptive.Base.IDo;
using MUS.Entities.Trait.Descriptive.Base.IHave;
using MUS.Entities.Trait.Functional.Base.ICan;
using MUS.Entities.Trait.Functional.Base.IDo;

namespace MUS.Entities.Base.Actor
{
    [Noun(Common.Enums.Data.Functional.TargetType.Actor, "Actor", "Person", "Character", "Char", "C")]
    public class BaseActor : Entity, IHaveHeight, ICanBePickedUpIfImDead
    {
        public IHeight Height { get; private set; }
        public IWeight Weight { get; private set; }
        public IDoDie DoDie { get; private set; }
        public IDoBePickedUp DoCanBePickedUp { get; private set; }

        public BaseActor(IDoDie die, IHeight height, IWeight weight) { DoDie = die; Height = height; Weight = weight; }
    }
}
