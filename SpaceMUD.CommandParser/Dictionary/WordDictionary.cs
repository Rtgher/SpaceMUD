using System;
using System.Collections.Generic;
using System.Linq;
using SpaceMUD.CommandParser.TreeParser.Words;
using SpaceMUD.Common.Dependency;
using SpaceMUD.Common.Enums.Client.Commands.Configuration;
using SpaceMUD.Common.Interfaces;
using SpaceMUD.Common.Tools.Attributes.Parser;
using SpaceMUD.Common.Tools.Extensions;
using SpaceMUD.Entities.Base;
using SpaceMUD.Common.Tools.Attributes.Parser.ImplicitWords;

namespace SpaceMUD.CommandParser.Dictionary
{
    public class WordDictionary
    {
        public const char MultiWord = ' ';
        public Dictionary<char, List<Word>> Lexic { get; private set; }
        private ILog _log = DependencyContainer.Provider.GetService(typeof(ILog)) as ILog;

        public WordDictionary()
        {
            Lexic = new Dictionary<char, List<Word>>();
            AddToLexic(typeof(CreateAccountCommand));
            AddToLexic(typeof(LoginCommand));
            AddToLexic(typeof(AttributionConjunction));
        }

        public void AddToLexic(Type type)
        {
            var memberInfo = type.GetMember(type.ToString());
            var partOfSpeech = memberInfo[0].GetCustomAttributes(typeof(PartOfSpeechAttribute), false);
            if (partOfSpeech.IsFixedSize == null || partOfSpeech.Length == 0)
                _log.LogWarning($"Tried to get a partofspeech attribute from Type '{type.Name}' but got nothing.");
            AddToLexic(partOfSpeech);
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
            foreach (var synonym in partOfSpeech.Synonyms)
            {
                AddToLexic(synonym, partOfSpeech);
            }
        }

        public PartOfSpeechAttribute FindInLexic(string word)
        {
            var searchItem = word.Trim();
            var startingChar = word[0];

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
            char startChar = word.TrimStart().FirstOrDefault();
            if (word.Contains(MultiWord)) startChar = MultiWord;
            if(Lexic.ContainsKey(startChar))
            {
                if (Lexic[startChar].Find(item => item.Value == word)==null) //don't add if already there.
                    Lexic[startChar].Add(new Word(word, attribute));
            }
            else
            {
                Lexic.Add(startChar, new List<Word>(){new Word(word, attribute)});
            }
        }
    }
}
