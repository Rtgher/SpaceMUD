using Microsoft.Extensions.DependencyInjection;
using MUS.Common.Interfaces;
using MUS.Database.Repositor.Base.Interface;
using MUS.Entities.Network;

namespace MUS.Database.Repositor
{
    public static class Repos
    {
        public static IRepository<Account> Account => GetRepositoryFor<Account>();

        public static IRepository<T> GetRepositoryFor<T>() where T : IDatabaseObject
        {
            return DependencyContainer.Provider.GetService<IRepository<T>>();
        }
    }
}
