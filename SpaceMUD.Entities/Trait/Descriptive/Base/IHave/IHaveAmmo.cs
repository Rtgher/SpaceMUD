using SpaceMUD.Entities.Trait.Descriptive.Base.IDo;
using SpaceMUD.Entities.Trait.Functional.Base.IDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Entities.Trait.Descriptive.Base.IHave
{
    public interface IHaveAmmo : IDoDamage
    {
        /// <summary>
        /// Add multiple IAmmo entities to simmulate magazines.
        /// </summary>
        IEnumerable<IAmmo> Magazines { get; }

        /// <summary>
        /// A Method to reload ammo.
        /// </summary>
        /// <returns>True if reload was successful.</returns>
        bool Reload();
    }
}
