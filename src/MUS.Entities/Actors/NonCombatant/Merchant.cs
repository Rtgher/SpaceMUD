using MUS.Entities.Base.Actor;
using MUS.Entities.Trait.Descriptive.Base.IDo;
using MUS.Entities.Trait.Functional.Base.IDo;

namespace MUS.Entities.Actors.NonCombatant
{
    internal class Merchant : BaseActor
    {
        public Merchant(IDoDie die, IHeight height, IWeight weight) : base(die, height, weight)
        {
        }
    }
}
