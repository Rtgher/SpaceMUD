using System.Collections.Generic;
using System.Linq;
using MUS.Common.Enums.Data.Functional;
using MUS.Common.Tools.Attributes.Parser;
using MUS.Entities.Trait.Descriptive.Base.IDo;
using MUS.Entities.Trait.Descriptive.Base.IHave;

namespace MUS.Entities.Items.Usables.Weapons
{
    [Noun(TargetType.Actor | TargetType.Item | TargetType.Vehicle, "gun", "range weapon", "ranged weapon", "rw")]
    public class RangeWeapon : MeleeWeapon, IHaveAmmo
    {
        public IEnumerable<IAmmo> Magazines { get; } = new List<IAmmo>();
        private IAmmo _currentMag = null;

        public bool Reload()
        {
            if (_currentMag == null)
            {
                _currentMag = Magazines.First();
                return true;
            }
            foreach (var mag in Magazines)
            {
                if (mag != _currentMag && mag.CurrentAmmo > _currentMag.CurrentAmmo)
                {
                    _currentMag = mag;
                    return true;
                }
            }

            return false;
        }
    }
}
