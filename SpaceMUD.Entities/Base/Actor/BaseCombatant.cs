using SpaceMUD.Entities.Trait.Functional.Base.ICan;
using SpaceMUD.Entities.Trait.Descriptive.Base.IDo;
using SpaceMUD.Entities.Trait.Functional.Base.IDo;
using System.Collections.Generic;

namespace SpaceMUD.Entities.Base.Actor
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
