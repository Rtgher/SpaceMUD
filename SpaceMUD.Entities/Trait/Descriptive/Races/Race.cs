using SpaceMUD.Data.Base.Interface;
using SpaceMUD.Entities.Base;
using SpaceMUD.Entities.Trait.Functional.Base.ICan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Entities.Trait.Functional.Base.IDo;

namespace SpaceMUD.Entities.Trait.Descriptive.Races
{
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
