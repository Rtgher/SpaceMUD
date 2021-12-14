using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceMUD.CommandParser.Dependency;
using SpaceMUD.CommandParser.Base;
using SpaceMUD.CommandParser.TreeParser;
using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Common.Enums.Client.Commands.Configuration;

namespace SpaceMUD.CommandParser.Tests.TreeParser
{
    [TestClass]
    public class TreeParserTests
    {
        [TestMethod]
        public void TestTreeParserInnit()
        {
            var provider = DependencyContainer.Provider.GetService(typeof(ICommandParser));
            Assert.IsNotNull(provider);
            Assert.IsInstanceOfType(provider, typeof(SpaceMUD.CommandParser.TreeParser.TreeParser));
        }

        [TestMethod]
        public void TestTreeParser_CreatesATree()
        {
            string command = "login test1 test1";
            var parser = DependencyContainer.Provider.GetService(typeof(ICommandParser)) as ICommandParser;
            var parsedCommand = parser.ParseCommand(command);
            Assert.IsNotNull(parsedCommand);
        }

        [TestMethod]
        public void TestTreeParser_CreatesALoginCommandTree()
        {
            string command = "login test1 test1";
            var parser = DependencyContainer.Provider.GetService(typeof(ICommandParser)) as ICommandParser;
            var parsedCommand = parser.ParseCommand(command);
            Assert.IsInstanceOfType(parsedCommand, typeof(ICommand));
            Assert.IsInstanceOfType(parsedCommand, typeof(LoginCommand));
        }

        [TestMethod]
        public void TestTreeParser_CreatesACreateAccountCommandTree()
        {
            string command = "create test1 test1";
            var parser = DependencyContainer.Provider.GetService(typeof(ICommandParser)) as ICommandParser;
            var parsedCommand = parser.ParseCommand(command);
            Assert.IsInstanceOfType(parsedCommand, typeof(ICommand));
            Assert.IsInstanceOfType(parsedCommand, typeof(CreateAccountCommand));
        }

        [TestMethod]
        public void TestTreeParser_CreatesAdjectivesFromUnknownTokens()
        {
            string command = "create testUnknown testUnknown";
            var parser = DependencyContainer.Provider.GetService(typeof(ICommandParser)) as ICommandParser;
            var parsedCommand = parser.ParseCommand(command);
            Assert.IsNotNull(parsedCommand.RawData.Values);
        }
    }
}
