using Microsoft.Extensions.DependencyInjection;
using MUS.Common.Exceptions.Database;
using MUS.Common.Interfaces;
using MUS.Entities.Actors.Player;
using MUS.Entities.LinkObjects;
using MUS.Entities.World;
using MUS.GameDriver.Functional.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MUS.GameDriver
{
    public class Game : IGame
    {
        public IList<PlayerCharacter> LoggedCharacters = new List<PlayerCharacter>();
        public IList<Location> LoadedLocations = new List<Location>();

        private ILog _log = Common.Dependency.DependencyContainer.Log;

        public bool LoadCharacter(long playerCharacterId)
        {
            try
            {
                var playerCharacter = Database.Repositor.DependencyContainer.GetRepositoryFor<PlayerCharacter>().GetSingle(playerCharacterId);
                LoggedCharacters.Add(playerCharacter.Load());
                var playerLocationId =
                                (from entityLocation in Database.Repositor.DependencyContainer.GetRepositoryFor<EntityLocation>().GetAll()
                                 where entityLocation.EntityId == playerCharacterId
                                 select entityLocation.LocationId).Single();
                LoadLocation(playerLocationId);
                _log.LogInfo($"Character Id {playerCharacterId} has been loaded to server game.");
                return true;
            }
            catch(MUSDatabaseNoDataException noData)
            {
                _log.LogError("Cannot load invalid character Id.", noData);
                return false;
            }

        }

        public bool LoadLocation(long locationId)
        {
            
            if (LoadedLocations.FirstOrDefault(location => location.Id == locationId) == null)
            {
                var location = Database.Repositor.DependencyContainer.GetRepositoryFor<Location>().GetSingle(locationId);
                LoadedLocations.Add(location.Load());
            }
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
