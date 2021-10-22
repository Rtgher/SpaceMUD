using System;
using SpaceMUD.Database.Repositor.Base.Interface;
using Microsoft.Extensions.DependencyInjection;
using SpaceMUD.Database.Repositor.FileRepository;

namespace SpaceMUD.Database.Repositor
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
