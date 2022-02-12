using MUS.Common.Interfaces;
using System.Collections.Generic;

namespace MUS.GameDriver
{
    public class Game : IGame
    {
        public IList<long> LoggedCharacterIds = new List<long>();
        public IList<long> LoadedlocationIds = new List<long>();

        public void LoadCharacter(long playerCharacterId)
        {
            throw new System.NotImplementedException();
        }

        public void LoadLocation(long locationId)
        {
            throw new System.NotImplementedException();
        }

        public void UnloadCharacter(long playerCharacterId)
        {
            throw new System.NotImplementedException();
        }

        public void UnloadLocation(long locationId)
        {
            throw new System.NotImplementedException();
        }
    }
}
