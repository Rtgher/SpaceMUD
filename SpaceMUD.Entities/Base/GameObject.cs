using SpaceMUD.Data.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Entities.Base
{
    public abstract class GameObject : IDatabaseObject
    {
        /// <summary>
        /// Name of the Game Object. This is the human-readable id of the game object in question.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the item in question. 
        /// </summary>
        public string Description { get; set; }

    }
}
