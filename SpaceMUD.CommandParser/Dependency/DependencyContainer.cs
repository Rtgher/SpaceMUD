﻿using Microsoft.Extensions.DependencyInjection;
using SpaceMUD.CommandParser.Base;
using SpaceMUD.CommandParser.Dictionary;
using SpaceMUD.CommandParser.TreeParser.Node;
using System;

namespace SpaceMUD.CommandParser.Dependency
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
            self.AddScoped<ICommandParser, TreeParser.TreeParser>();
            self.AddScoped<ILexic, WordDictionary>();
            return self;
        }
    }
}