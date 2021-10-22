using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpaceMUD.Server.Base.Interface;
using SpaceMUD.Server;
using SpaceMUD.Server.Base.Interface.Connection;
using SpaceMUD.Server.Connection;
using SpaceMUD.Common.Interfaces;
using SpaceMUD.Common.Logging;

namespace SpaceMUD.Base.Tools.Dependency.ServiceContainer
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
