using SpaceMUD.Common.Enums.Data.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Entities.Trait.Functional.Base.IDo
{
    public interface IDoDie
    {
        /// <summary>
        /// Maximum health value of an object.
        /// </summary>
        int MaxHealth { get; }

        /// <summary>
        /// Current Health value of an object.
        /// </summary>
        int Health { get; }

        /// <summary>
        /// Returns a bool value on whether the object is alive or not.
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        /// Armour Value of the killable item.
        /// </summary>
        ArmourClass ArmourValue { get; }

        /// <summary>
        /// Take damage or receive heal.
        /// Positive amount receives heal.
        /// Negative amount receives damage.
        /// </summary>
        /// <param name="amount">Amount to heal/damage.</param>
        void AlterHealth(int amount);

        /// <summary>
        /// Causes object to die.
        /// </summary>
        void Die();
    }
}
