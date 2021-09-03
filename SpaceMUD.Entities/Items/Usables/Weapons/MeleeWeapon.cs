using SpaceMUD.Entities.Trait.Functional.Base.IDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Data.Functional;
using SpaceMUD.Entities.Trait.Descriptive.Base.IHave;
using SpaceMUD.Common.Tools.Attributes.Parser;

namespace SpaceMUD.Entities.Items.Usables.Weapons
{
    [Noun(TargetType.Actor|TargetType.Item|TargetType.Vehicle, "Weapon")]
    public class MeleeWeapon : PickableItem, IDoDamage, IHaveValue
    {
        public DamageType DamageType { get; set; }

        public int Damage { get; private set; }

        public int Value {get;set;}

        public int MaximumRange { get; }

        public virtual ArmourClass PenetrationPower { get; private set; }
    }
}
