using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Entities.Trait.Functional.Base.ICan
{
    public interface ICanDie
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
        /// Take damage or receive heal.
        /// Positive amount receives heal.
        /// Negative amount receives damage.
        /// </summary>
        /// <param name="amount"></param>
        void AlterHealth(int amount);

        /// <summary>
        /// Causes object to die.
        /// </summary>
        void Die();

    }
}
