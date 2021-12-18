﻿using System;
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

        public IWordTree Tree { get; private set; }

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
            var parseTree = ParseTree(command);
            var verbs = parseTree.GetParts(WordTypeEnum.Verb);
            for(int i=0; i<verbs.Count(); i++)
            {
                var verb = verbs.ElementAt(i);

                ICommand buildingCommand =  BuildCommand(parseTree, verb);

                if (parsedCommand == null) parsedCommand = buildingCommand;
                else parsedCommand.AddFollowUpCommand(buildingCommand);
            }

            Tree = parseTree;
            return parsedCommand;
        }

        private ICommand BuildCommand(IWordTree tree, Node.INode verb)
        {
            ICommand command = null;
            Type commandType = FindCommandType(verb);
            command = (ICommand)Activator.CreateInstance(commandType);

            bool reachedNode = false;
            foreach (var leaf in tree.ParseTree())
            {
                int countUnknown = 0;
                if (leaf == verb)
                {
                    reachedNode = true;
                    continue;
                }
                if (!reachedNode) continue;//we only want to check the nodes in between the current verb node and the next verb node.
                if (leaf.Value.PartOfSpeechType == WordTypeEnum.Verb) break;
                if (leaf.Value.PartOfSpeechType == WordTypeEnum.Adverb)
                {
                    command.RawData.AdverbValues.Add(leaf.Value.Value);
                }
                if (leaf.Value.PartOfSpeechType == WordTypeEnum.Equalizer)
                {
                    command.RawData.Values.Add(leaf.Left.Value.Value, leaf.Right.Value.Value);
                    tree.GetEnumerator().MoveNext();
                    tree.GetEnumerator().MoveNext();//skip over the two added values.
                }
                if (leaf.Value.PartOfSpeechType == WordTypeEnum.Adjective)
                {
                    command.RawData.Values.Add((countUnknown++).ToString(), leaf.Value.Value);
                }
                if (leaf.Value.PartOfSpeechType == WordTypeEnum.Noun)
                {
                    if (leaf.Left != null && leaf.Left.Value.PartOfSpeechType == WordTypeEnum.Adjective)
                    {
                        command.RawData.Values.Add((countUnknown++).ToString(), leaf.Left.Value.Value + " " + leaf.Value.Value);
                        tree.GetEnumerator().MoveNext();
                    }
                }
                if (leaf.Value.PartOfSpeechType == WordTypeEnum.Preposition) continue;
            }
            return command;
        }

        private Type FindCommandType(Node.INode verb)
        {
            Type commandType = null;

            foreach (var commType in CommandsTypelList)
            {
                if (commType.GetAttribute<PartOfSpeechAttribute>().Synonyms.Contains(verb.Value.Value))
                {
                    commandType = commType;
                    break;
                }
            }

            return commandType;
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
