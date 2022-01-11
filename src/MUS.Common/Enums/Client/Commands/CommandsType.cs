using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUS.Common.Enums.Client.Commands
{
    public enum CommandsType
    {
        /// <summary>
        /// Talking, emoting, roleplaying
        /// </summary>
        Social = 1,
        /// <summary>
        /// Creating character, configuring stats, setting up account, describing stuff, etc
        /// </summary>
        Configuration = 2,
        /// <summary>
        /// Describe a speciifc item, list a shop list, list inventory, etc.
        /// </summary>
        Descriptive = 3,
        /// <summary>
        /// Attacking, etc
        /// </summary>
        Combat = 4,
        /// <summary>
        /// Boarding vehicles, moving between rooms, moving within the room, etc
        /// </summary>
        Movement = 8,
        /// <summary>
        /// Picking up stuff from ground, accessing inventory, buying from shops, etc.
        /// </summary>
        Functional = 16,
        Ordering = 32,



    }
}
