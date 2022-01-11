using System.Collections.Generic;
using MUS.Entities.Trait.Descriptive.Base.IDo;
using MUS.Entities.Trait.Functional.Base.IDo;
using MUS.Entities.Trait.Functional.Base.ICan;

namespace MUS.Entities.Base.Actor
{
    public class BaseCombatant : BaseActor, ICanFight, ICanBeVulnerable
    {
        public BaseCombatant(IDoFight fight, IDoDie die, IHeight height, IWeight weight) : base(die, height, weight)
        {
            //TODO: Assign and create units.
        }

        public IDoFight DoFight { get; private set; }

        public IList<IDoVulnerable> Vulnerabilities { get; private set; } = new List<IDoVulnerable>();
    }
}
