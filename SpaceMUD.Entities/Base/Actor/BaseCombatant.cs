using SpaceMUD.Entities.Trait.Functional.Base.ICan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Entities.Trait.Descriptive.Base.IDo;

namespace SpaceMUD.Entities.Base.Actor
{
    public class BaseCombatant : BaseActor, ICanFight, ICanDie
    {
        public BaseCombatant(ICanFight fight, ICanDie die, IHeight height, IWeight weight) : base(height, weight)
        {
            //TODO: Assign and create units.
        }
    }
}
