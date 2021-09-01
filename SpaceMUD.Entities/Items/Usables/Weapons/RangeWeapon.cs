using SpaceMUD.Entities.Trait.Descriptive.Base.IHave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Entities.Trait.Descriptive.Base.IDo;

namespace SpaceMUD.Entities.Items.Usables.Weapons
{
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
