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
    }
}
