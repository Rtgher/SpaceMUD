using MUS.Entities.Base.Actor;
using MUS.Entities.Trait.Descriptive.Base.IDo;
using MUS.Entities.Trait.Functional.Base.IDo;
namespace MUS.Entities.Actors.Player
{
    public class PlayerCharacter : BaseCombatant
    {
        public PlayerCharacter(IDoFight fight, IDoDie die, IHeight height, IWeight weight) : base(fight, die, height, weight)
        {
        }
    }
}
