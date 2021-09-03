using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.CommandParser.TreeParser.Enums
{
    public enum WordTypeEnum
    {
        Verb = 1,
        Noun = 2,
        Adverb = 4,
        Adjective = 8,
        /// <summary>
        /// IN/AT/ON/OF/A/etc...
        /// </summary>
        Preposition = 16,
        /// <summary>
        /// AND/BUT/ALTHOUGH/etc...
        /// </summary>
        Conjuction = 32

    }
}
