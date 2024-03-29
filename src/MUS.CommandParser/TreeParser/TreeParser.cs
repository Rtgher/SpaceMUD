﻿using MUS.CommandParser.Base;
using MUS.CommandParser.Constants;
using MUS.CommandParser.Dependency;
using MUS.CommandParser.TreeParser.Base;
using MUS.CommandParser.TreeParser.Words;
using MUS.Common.Commands.Base;
using MUS.Common.Commands.Configuration;
using MUS.Common.Enums.Parser;
using MUS.Common.Tools.Attributes.Parser;
using MUS.Common.Tools.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MUS.CommandParser.TreeParser
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
            ICommand buildingCommand;
            for (int i = 0; i < verbs.Count(); i++)
            {
                var verb = verbs.ElementAt(i);

                buildingCommand = BuildCommand(parseTree, verb);

                if (parsedCommand == null) parsedCommand = buildingCommand;
                else parsedCommand.AddFollowUpCommand(buildingCommand);
            }
            if (verbs.Count() == 0 && parseTree.Count() != 0)
            {
                buildingCommand = BuildFollowUpCommand(parseTree);
            }
            if (parsedCommand == null) parsedCommand = new InvalidCommand(null);
            Tree = parseTree;
            parsedCommand.CommandString = command;
            return parsedCommand;
        }

        private ICommand BuildFollowUpCommand(IWordTree parseTree)
        {
            ICommand continuationCommand = new ContinuationCommand();
            return ExtractTree(parseTree, null, continuationCommand);
        }

        private ICommand BuildCommand(IWordTree tree, Node.INode verb)
        {
            ICommand command = null;
            Type commandType = FindCommandType(verb);
            command = (ICommand)Activator.CreateInstance(commandType);
            return ExtractTree(tree, verb, command);
        }

        private static ICommand ExtractTree(IWordTree tree, Node.INode verb, ICommand command)
        {
            bool reachedNode = false;
            var parsedTree = tree.ParseTree().ToList();
            for (int i = 0; i < parsedTree.Count(); i++)
            {
                var leaf = parsedTree[i];
                if (leaf == verb && verb != null)
                {
                    reachedNode = true;
                    continue;
                }
                if (!reachedNode && verb != null) continue;//we only want to check the nodes in between the current verb node and the next verb node.
                if (leaf.Content.PartOfSpeechType == WordTypeEnum.Verb) break;
                if (leaf.Content.PartOfSpeechType == WordTypeEnum.Adverb)
                {
                    command.RawData.AdverbValues.Add(leaf.Content.Value);
                }
                if (leaf.Content.PartOfSpeechType == WordTypeEnum.Equalizer)
                {
                    command.RawData.Values.Add(leaf.Left.Content.Value.ToLowerInvariant(), leaf.Right.Content.Value);
                    i += 2;//skip over the two added values.
                }
                if (leaf.Content.PartOfSpeechType == WordTypeEnum.Adjective)
                {
                    command.RawData.UnspecifiedArguments.Add(leaf.Content.Value);
                }
                if (leaf.Content.PartOfSpeechType == WordTypeEnum.Noun)
                {
                    if (leaf.Left != null && leaf.Left.Content.PartOfSpeechType == WordTypeEnum.Adjective)
                    {
                        if (((NounAttribute)leaf.Content.Attribute).IsType == Common.Enums.Data.Functional.TargetType.DataField)
                        {
                            command.RawData.Values.Add(leaf.Content.Value, leaf.Left.Content.Value);
                        }
                        else
                        {
                            command.RawData.UnspecifiedArguments.Add($"{leaf.Left.Content.Value} {leaf.Content.Value}");
                        }
                        i++;
                    }
                }
                if (leaf.Content.PartOfSpeechType == WordTypeEnum.Preposition) continue;
            }
            return command;
        }

        private Type FindCommandType(Node.INode verb)
        {
            Type commandType = null;

            foreach (var commType in CommandsTypelList)
            {
                if (commType.GetAttribute<PartOfSpeechAttribute>().Synonyms.Contains(verb.Content.Value, StringComparer.InvariantCultureIgnoreCase))
                {
                    commandType = commType;
                    break;
                }
            }

            return commandType;
        }

        private IWordTree ParseTree(string command)
        {
            IWordTree tree = DependencyContainer.Provider.GetService(typeof(IWordTree)) as IWordTree;
            var words = Regex.Split(command, CommandParserConstants.TokenRegexSplitBy);
            words = words.Where(s => s != string.Empty && !string.IsNullOrWhiteSpace(s)).ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == string.Empty) continue;
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
