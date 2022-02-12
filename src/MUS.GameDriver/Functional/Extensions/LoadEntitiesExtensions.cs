using MUS.Database.Repositor;
using MUS.Entities.Actors.Player;
using MUS.Entities.World;


namespace MUS.GameDriver.Functional.Extensions
{
    internal static class LoadEntitiesExtensions
    {
        internal static PlayerCharacter Load(this PlayerCharacter playerCharacter)
        {
            return playerCharacter;
        }

        internal static Location Load(this Location location)
        {
            return location;
        }
    }
}
