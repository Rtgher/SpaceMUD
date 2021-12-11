using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceMUD.CommandParser.Dependency;
using SpaceMUD.CommandParser.Base;
using SpaceMUD.CommandParser.TreeParser;

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


    }
}
