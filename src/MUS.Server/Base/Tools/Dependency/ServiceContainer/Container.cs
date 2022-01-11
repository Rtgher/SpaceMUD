using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MUS.Server.Base.Interface;
using MUS.Server.Base.Interface.Connection;
using MUS.Server.Server;
using MUS.Server.Server.Connection;
using System;

namespace MUS.Server.Base.Tools.Dependency.ServiceContainer
{
    public static class Container
    {
        private static IHost _base = null;
        private static IServiceCollection _services = new ServiceCollection();
        private static IServiceProvider _provider;

        public static IServiceProvider Provider(IServiceCollection services) => _provider = _provider ?? services.BuildServiceProvider();

        public static IServiceCollection ConfigureServicesForSocketServer()
        {
            _services.AddScoped<IServer, TelnetSocketServer>()
                .AddScoped<ISocketConnection, SocketConnectionHandler>();
            return _services;
        }
    }
}
