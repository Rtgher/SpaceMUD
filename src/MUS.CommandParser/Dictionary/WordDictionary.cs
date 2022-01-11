using MUS.CommandParser.Base;
using MUS.CommandParser.TreeParser.Words;
using MUS.Common.Commands.CommandData;
using MUS.Common.Commands.Configuration;
using MUS.Common.Dependency;
using MUS.Common.Interfaces;
using MUS.Common.Tools.Attributes.Parser;
using MUS.Common.Tools.Attributes.Parser.ImplicitWords;
using MUS.Common.Tools.Extensions;
using MUS.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MUS.CommandParser.Dictionary
{
    public class WordDictionary : ILexic
    {
        public const char MultiWord = ' ';
        public Dictionary<char, List<Word>> Lexic { get; private set; }
        private ILog _log = DependencyContainer.Provider.GetService(typeof(ILog)) as ILog;

        public WordDictionary()
        {
            Lexic = new Dictionary<char, List<Word>>();
            AddToLexic(typeof(CreateAccountCommand));
            AddToLexic(typeof(CreateAccountCommandData));
            AddToLexic(typeof(LoginCommand));
            AddToLexic(typeof(LoginCommandData));
            AddToLexic(typeof(EqualizerClass));

        }

        public void AddToLexic(Type type)
        {
            var partOfSpeech = type.GetAttribute<PartOfSpeechAttribute>();
            var decoratedPropertyAttributes = from property in type.GetProperties()
                                              where Attribute.IsDefined(property, typeof(PartOfSpeechAttribute))
                                              select property.GetCustomAttributes(typeof(PartOfSpeechAttribute), false).First() as PartOfSpeechAttribute;
            if (partOfSpeech == null)
            {
                _log.LogWarning($"Tried to get a partofspeech attribute from Type '{type.Name}' but got nothing.");
            }
            else
            {
                AddToLexic(partOfSpeech);
            }
            foreach (var propAtt in decoratedPropertyAttributes) AddToLexic(propAtt);
        }

        public void AddToLexic(IEnumerable<GameObject> objects)
        {
            foreach (var gameObject in objects)
            {
                AddToLexic(gameObject);
            }
        }

        public void AddToLexic(object obj)
        {
            var partOfSpeech = obj.GetAttribute<PartOfSpeechAttribute>();
            if (partOfSpeech == null)
            {
                _log.LogWarning($"Tried to get a partofspeech attribute from class '{obj.GetType().Name}' but got nothing.");
                return;
            }
            AddToLexic(partOfSpeech);
        }

        public void AddToLexic(PartOfSpeechAttribute partOfSpeech)
        {
            _log.LogInfo($"Adding new part of speech info from type '{partOfSpeech.ParOfSpeechType.ToString("G")}' Synonyms: {partOfSpeech.Synonyms.Aggregate<string>((s1, s2) => $"{s1},{s2}")}.");
            foreach (var synonym in partOfSpeech.Synonyms)
            {
                AddToLexic(synonym, partOfSpeech);
            }
        }

        public PartOfSpeechAttribute FindInLexic(string word)
        {
            var searchItem = word.Trim();
            var startingChar = char.ToLowerInvariant(word[0]);
            if (!Lexic.ContainsKey(startingChar)) return null;

            var registeredWords = Lexic[startingChar];
            foreach (var registeredWord in registeredWords)
            {
                if (registeredWord.Value.Equals(searchItem, StringComparison.CurrentCultureIgnoreCase))
                {
                    return registeredWord.Attribute;
                }
            }

            _log.LogWarning($"Could not find word '{word}' in Lexic.");
            return null;
        }

        public bool IsInLexic(string word)
        {
            if (FindInLexic(word) != null) return true;
            else return false;
        }

        public bool IsInLexic(PartOfSpeechAttribute attribute)
        {
            if (attribute.Synonyms.Any(word => IsInLexic(word))) return true;
            else return false;
        }

        private void AddToLexic(string word, PartOfSpeechAttribute attribute)
        {
            char startChar = word.ToLowerInvariant().TrimStart().First();
            if (word.Contains(MultiWord)) startChar = MultiWord;
            if (Lexic.ContainsKey(startChar))
            {
                if (Lexic[startChar].Find(item => item.Value == word) == null) //don't add if already there.
                    Lexic[startChar].Add(new Word(word, attribute));
            }
            else
            {
                Lexic.Add(startChar, new List<Word>() { new Word(word, attribute) });
            }
        }
    }
}
