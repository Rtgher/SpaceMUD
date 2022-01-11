using Microsoft.Extensions.DependencyInjection;
using MUS.CommandParser.Base;
using MUS.CommandParser.Dictionary;
using MUS.CommandParser.TreeParser;
using MUS.CommandParser.TreeParser.Base;
using MUS.CommandParser.TreeParser.Node;
using System;

namespace MUS.CommandParser.Dependency
{
    public static class DependencyContainer
    {
        private static IServiceCollection _services = new ServiceCollection();
        private static IServiceProvider _provider;

        public static IServiceProvider Provider => _provider = _provider ?? _services.ConfigureServicesForTreeParser()
                                                                   .BuildServiceProvider();

        public static IServiceCollection ConfigureServicesForTreeParser(this IServiceCollection self)
        {
            self.AddScoped<INode, WordNode>();
            self.AddTransient<ICommandParser, TreeParser.TreeParser>();
            self.AddScoped<ILexic, WordDictionary>();
            self.AddTransient<IWordTree, WordTree>();
            return self;
        }
    }
}
