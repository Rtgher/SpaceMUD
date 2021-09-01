using SpaceMUD.Common.Enums.Data.Functional;


namespace SpaceMUD.Entities.Trait.Functional.Base.IDo
{
    public interface IDoDamage
    {
        /// <summary>
        /// Damage Type of the bullet.
        /// </summary>
        DamageType DamageType { get; }

        /// <summary>
        /// The actual damage this Ammo inflicts
        /// </summary>
        int Damage { get; }

        /// <summary>
        /// The maximum range for which the IDoDamage object can affect at.
        /// 0 for melee.
        /// </summary>
        int MaximumRange { get; }

        /// <summary>
        /// Level of armour penetration from 0 to 5.
        /// </summary>
        ArmourClass PenetrationPower { get; }
    }
}
