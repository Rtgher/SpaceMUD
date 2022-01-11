using NUnit.Framework;
using MUS.CommandParser.Base;
using MUS.CommandParser.Dependency;
using System;
using MUS.Common.Commands.Base;
using MUS.Common.Commands.Configuration;
using MUS.Common.Enums.Parser;

namespace MUS.CommandParser.Tests.TreeParser
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTreeParserInnit()
        {
            var provider = DependencyContainer.Provider.GetService(typeof(ICommandParser));
            Assert.IsNotNull(provider);
            Assert.IsInstanceOf(typeof(MUS.CommandParser.TreeParser.TreeParser),provider);
        }

        [Test]
        public void TestTreeParser_CreatesATree()
        {
            string command = "login test1 test1";
            var parser = DependencyContainer.Provider.GetService(typeof(ICommandParser)) as ICommandParser;
            var parsedCommand = parser.ParseCommand(command);
            Assert.IsNotNull(parsedCommand);
        }

        [Test]
        public void TestTreeParser_CreatesALoginCommandTree()
        {
            string command = "login test1 test1";
            var parser = DependencyContainer.Provider.GetService(typeof(ICommandParser)) as ICommandParser;
            var parsedCommand = parser.ParseCommand(command);
            Assert.IsInstanceOf(typeof(ICommand), parsedCommand);
            Assert.IsInstanceOf(typeof(LoginCommand), parsedCommand);
        }

        [Test]
        public void TestTreeParser_CreatesACreateAccountCommandTree()
        {
            string command = "create test1 test1";
            var parser = DependencyContainer.Provider.GetService(typeof(ICommandParser)) as ICommandParser;
            var parsedCommand = parser.ParseCommand(command);
            Assert.IsInstanceOf(typeof(ICommand), parsedCommand);
            Assert.IsInstanceOf(typeof(CreateAccountCommand), parsedCommand);
        }

        [Test]
        public void TestTreeParser_CreatesAdjectivesFromUnknownTokens()
        {
            string command = "create testUnknown testUnknown";
            var parser = DependencyContainer.Provider.GetService(typeof(ICommandParser)) as ICommandParser;
            var parsedCommand = parser.ParseCommand(command);
            Assert.IsNotNull(parsedCommand.RawData.Values);
            Assert.IsNotNull(parser.Tree.SearchTree(WordTypeEnum.Adjective));
            Assert.IsNotNull(parser.Tree.SearchTree(WordTypeEnum.Adjective, 2));
        }

        [Test]
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

        [Test]
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