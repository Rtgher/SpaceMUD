using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SpaceMUD.Data.Base.Interface;
using SpaceMUD.Database.Repositor.Base.Interface;
using SpaceMUD.Entities.Network;

namespace SpaceMUD.Database.Repositor
{
    public static class Repos
    {
        public static IRepository<Account> Account => GetRepositoryFor<Account>();

        public static IRepository<T> GetRepositoryFor<T>() where T: IDatabaseObject
        {
            return DependencyContainer.Provider.GetService<IRepository<T>>();
        }
    }
}
