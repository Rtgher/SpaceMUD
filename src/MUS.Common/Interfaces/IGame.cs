using MUS.Common.Interfaces.EntityInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUS.Common.Interfaces
{
    /// <summary>
    /// A blank interface to denote a game/application. 
    /// This is the game world you'll be running on the server.
    /// </summary>
    public interface IGame
    {
        bool LoadCharacter(long playerCharacterId);
        void UnloadCharacter(long playerCharacterId);
        bool LoadLocation(long locationId);
        void UnloadLocation(long locationId);
    }
}
