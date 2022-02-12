using MUS.Common.Interfaces;
using MUS.Common.Tools.Attributes.Parser;
using MUS.Entities.Trait.Functional.Base.ICan;
using MUS.Entities.Trait.Functional.Base.IDo;
using System.Collections.Generic;

namespace MUS.Entities.Trait.Descriptive.Races
{
    [Adjective("Race", "Species", "Kin")]
    public abstract class Race : IDatabaseObject, ICanBeVulnerable
    {
        /// <summary>
        /// Name of the race.
        /// </summary>
        public string RaceName { get; protected set; }

        /// <summary>
        /// Numbers of years that race can live up to (on average).
        /// </summary>
        public int YearSpan { get; protected set; }

        /// <summary>
        /// A short description of the race.
        /// </summary>
        public string RacialDescription { get; protected set; }

        /// <summary>
        /// A short description of the race's physical appearance.
        /// </summary>
        public string Appearance { get; protected set; }

        public IList<IDoVulnerable> Vulnerabilities { get; } = new List<IDoVulnerable>();
    }
}
