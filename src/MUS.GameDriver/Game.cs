using MUS.Common.Interfaces;
using System.Collections.Generic;

namespace MUS.GameDriver
{
    public class Game : IGame
    {
        public IList<long> LoggedCharacterIds = new List<long>();
        public IList<long> LoadedlocationIds = new List<long>();


    }
}
