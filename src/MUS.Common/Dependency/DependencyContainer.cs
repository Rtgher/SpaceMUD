using Microsoft.Extensions.DependencyInjection;
using System;
using MUS.Common.Logging;
using MUS.Common.Tools;
using MUS.Common.Interfaces;

namespace MUS.Common.Dependency
{
    public static class DependencyContainer
    {
        private static IServiceCollection _services = new ServiceCollection();
        private static IServiceProvider _provider;
        public static IServiceProvider Provider => _provider = _provider ?? _services.ConfigureServiceForLogger().BuildServiceProvider();
                                                                   

        public static IServiceCollection ConfigureServiceForLogger(this IServiceCollection self)
        {
            self.AddSingleton<ILog>(new Logger(DirectoryHelper.GetInstalationDirectoryRoot().Parent.Parent.Parent.FullName + "/Logs/"));
            return self;
        }

        public static ILog Log { get=> Provider.GetService<ILog>(); }
    }
}
