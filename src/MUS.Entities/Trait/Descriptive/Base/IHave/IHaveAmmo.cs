﻿using MUS.Entities.Trait.Descriptive.Base.IDo;
using MUS.Entities.Trait.Functional.Base.IDo;
using System.Collections.Generic;

namespace MUS.Entities.Trait.Descriptive.Base.IHave
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
