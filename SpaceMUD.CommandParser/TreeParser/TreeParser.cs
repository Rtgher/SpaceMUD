using System;
using System.Collections.Generic;
using System.Linq;
using SpaceMUD.CommandParser.Base;
using SpaceMUD.CommandParser.Dictionary;
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
        public WordDictionary Lexic { get; }
        private readonly IEnumerable<Type> CommandsTypelList;

        public TreeParser(WordDictionary lexic)
        {
            Lexic = lexic;
            CommandsTypelList = new List<Type>();
            var commandAssembly = typeof(LoginCommand).Assembly;
            CommandsTypelList = commandAssembly.GetTypes()
                .Where(type => type.CustomAttributes.Any(attr => attr.AttributeType is PartOfSpeechAttribute));
        }

        public ICommand ParseCommand(string command)
        {
            var tree =  ParseTree(command);
            var verb = tree.SearchTree(WordTypeEnum.Verb);
            Type commandType = null;
            foreach (var commType in CommandsTypelList)
            {
                if (commType.GetAttribute<PartOfSpeechAttribute>().Synonyms.Contains(verb.Value.Value))
                {
                    commandType = commType;
                    break;
                }
            }

            ICommand parsedCommand = (ICommand) Activator.CreateInstance(commandType);
        }

        private IWordTree ParseTree(string command)
        {
            IWordTree tree;
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
                    tree.AddValue(new Word(word, partOfSpeech));
                }
                else
                {
                    var w = new Word(word, new AdjectiveAttribute(word));
                }

            }

            return tree;
        }
    }
}
