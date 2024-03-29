﻿using MUS.Common.Enums.Data.Functional;
using MUS.Common.Tools.Attributes.Parser;
using MUS.Entities.Trait.Descriptive.Base.IHave;
using MUS.Entities.Trait.Functional.Base.IDo;

namespace MUS.Entities.Items.Usables.Weapons
{
    [Noun(TargetType.Actor | TargetType.Item | TargetType.Vehicle, "Weapon")]
    public class MeleeWeapon : PickableItem, IDoDamage, IHaveValue
    {
        public DamageType DamageType { get; set; }

        public int Damage { get; private set; }

        public int Value { get; set; }

        public int MaximumRange { get; }

        public virtual ArmourClass PenetrationPower { get; private set; }
    }
}
