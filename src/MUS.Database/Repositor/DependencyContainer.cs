using System;
using Microsoft.Extensions.DependencyInjection;
using MUS.Database.Repositor.FileRepository;
using MUS.Database.Repositor.Base.Interface;

namespace MUS.Database.Repositor
{
    internal static class DependencyContainer
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

    }
}
