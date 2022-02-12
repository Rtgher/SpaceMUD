using System;
using Microsoft.Extensions.DependencyInjection;
using MUS.Database.Repositor.FileRepository;
using MUS.Database.Repositor.Base.Interface;
using MUS.Common.Interfaces;

namespace MUS.Database.Repositor
{
    public static class DependencyContainer
    {
        private static IServiceCollection _services = new ServiceCollection();
        private static IServiceProvider _provider;

        public static IServiceProvider Provider => _provider = _provider ??
                                                               _services.ConfigureServicesForFileRepository()
                                                                   .BuildServiceProvider();

        public static IServiceCollection ConfigureServicesForFileRepository(this IServiceCollection self)
        {
            self.AddScoped(typeof(IRepository<>), typeof(FileRepository<>));
            return self;
        }

        public static IRepository<T> GetRepositoryFor<T>() where T : IDatabaseObject
        {
            return _provider.GetService<IRepository<T>>();   
        }

    }
}
