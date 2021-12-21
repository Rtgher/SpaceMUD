using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceMUD.CommandParser.Dependency;
using SpaceMUD.CommandParser.Base;
using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Common.Enums.Client.Commands.Configuration;
using SpaceMUD.Common.Enums.Parser;

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
            Assert.IsNotNull(parser.Tree.SearchTree(WordTypeEnum.Adjective));
            Assert.IsNotNull(parser.Tree.SearchTree(WordTypeEnum.Adjective, 2));
        }

        [TestMethod]
        public void TestTreeParser_SentenceWithXWords_ContainsXLeafsInTree()
        {
            Random rng = new Random();
            string command = "login";
            int count = rng.Next(10);
            for (int i = 0; i < count; i++)
                command += " testX";

            var parser = DependencyContainer.Provider.GetService(typeof(ICommandParser)) as ICommandParser;
            var parsedCommand = parser.ParseCommand(command);

            Assert.AreEqual(count + 1, parser.Tree.Count());
        }

        [TestMethod]
        public void TestTreeParser_SentenceWithEqualizerAttribute_AssignsCorrectData()
        {
            string command = "create username=testUsername PassWord:testPassword";
            var parser = DependencyContainer.Provider.GetService(typeof(ICommandParser)) as ICommandParser;
            var parsedCommand = parser.ParseCommand(command);

            var createAccCommand = parsedCommand as CreateAccountCommand;
            Assert.AreEqual("testUsername", createAccCommand.ProcessedData.Username);
            Assert.AreEqual("testPassword", createAccCommand.ProcessedData.UnEncodedPassword);
        }
    }
}
