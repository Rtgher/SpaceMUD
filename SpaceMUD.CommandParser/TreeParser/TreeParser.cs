using System;
using System.Collections.Generic;
using System.Linq;
using SpaceMUD.CommandParser.Base;
using SpaceMUD.CommandParser.TreeParser.Base;
using SpaceMUD.CommandParser.TreeParser.Words;
using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Common.Enums.Client.Commands.Configuration;
using SpaceMUD.Common.Enums.Parser;
using SpaceMUD.Common.Tools.Attributes.Parser;
using SpaceMUD.Common.Tools.Extensions;

namespace SpaceMUD.CommandParser.TreeParser
{
    public class TreeParser : ICommandParser
    {
        public ILexic Lexic { get; }
        private readonly IEnumerable<Type> CommandsTypelList;

        public TreeParser(ILexic lexic)
        {
            Lexic = lexic;
            CommandsTypelList = new List<Type>();
            var commandAssembly = typeof(LoginCommand).Assembly;
            CommandsTypelList = commandAssembly.GetTypes()
                .Where(type => type.CustomAttributes.Any(attr => attr.AttributeType.IsSubclassOf(typeof(PartOfSpeechAttribute))));
        }

        public ICommand ParseCommand(string command)
        {
            ICommand parsedCommand = null;
            var tree = ParseTree(command);
            var verbs = tree.GetParts(WordTypeEnum.Verb);
            for(int i=0; i<verbs.Count(); i++)
            {
                ICommand buildingCommand = null;
                Type commandType = null;
                var verb = verbs.ElementAt(i);

                foreach (var commType in CommandsTypelList)
                {
                    if (commType.GetAttribute<PartOfSpeechAttribute>().Synonyms.Contains(verb.Value.Value))
                    {
                        commandType = commType;
                        break;
                    }
                }
                buildingCommand = (ICommand)Activator.CreateInstance(commandType);

                foreach (var leaf in tree.ParseTree())
                {
                    if (leaf == verb) continue;
                    if (leaf.Value.PartOfSpeechType == WordTypeEnum.Verb) break;
                }

                if (parsedCommand == null) parsedCommand = buildingCommand;
                else parsedCommand.AddFollowUpCommand(buildingCommand);
            }

            


            return parsedCommand;
        }

        private IWordTree ParseTree(string command)
        {
            IWordTree tree =  Dependency.DependencyContainer.Provider.GetService(typeof(IWordTree)) as IWordTree;
            var words = command.Split();
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (i + 1 < words.Length)
                {
                    var doubleword = word + ' ' + words[i + 1];
                    if (Lexic.IsInLexic(doubleword))
                    {
                        var pos = Lexic.FindInLexic(doubleword);
                        var w = new Word(doubleword, pos);
                        tree.AddValue(w);
                        i++;
                        continue;
                    }
                }

                var partOfSpeech = Lexic.FindInLexic(word);
                if (partOfSpeech != null)
                {
                    var addWord = new Word(word, partOfSpeech);
                    tree.AddValue(addWord);
                }
                else
                {
                    //in case we don't find anything, we pretend it's an adjective.
                    var w = new Word(word, new AdjectiveAttribute(word));
                    tree.AddValue(w);
                }

            }

            return tree;
        }
    }
}
