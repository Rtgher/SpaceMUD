using SpaceMUD.Entities.Trait.Descriptive.Base.IHave;
using System.Collections.Generic;
using System.Linq;
using SpaceMUD.Entities.Trait.Descriptive.Base.IDo;
using SpaceMUD.Common.Enums.Data.Functional;
using SpaceMUD.Common.Tools.Attributes.Parser;

namespace SpaceMUD.Entities.Items.Usables.Weapons
{
    [Noun(TargetType.Actor | TargetType.Item | TargetType.Vehicle, "Gun", "range weapon", "ranged weapon", "rw")]
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
            foreach(var mag in Magazines)
            {
                if (mag!=_currentMag && mag.CurrentAmmo > _currentMag.CurrentAmmo)
                {
                    _currentMag = mag;
                    return true;
                }
            }

            return false;
        }
    }
}
