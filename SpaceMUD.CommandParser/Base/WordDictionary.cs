using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceMUD.CommandParser.TreeParser.Words;
using SpaceMUD.Common.Dependency;
using SpaceMUD.Common.Enums.Client.Commands.Configuration;
using SpaceMUD.Common.Enums.Parser;
using SpaceMUD.Common.Interfaces;
using SpaceMUD.Common.Tools.Attributes.Parser;
using SpaceMUD.Common.Tools.Extensions;
using SpaceMUD.Entities.Base;

namespace SpaceMUD.CommandParser.Base
{
    public class WordDictionary
    {
        public Dictionary<char, List<Word>> Lexic { get; private set; }
        private ILog _log = DependencyContainer.Provider.GetService(typeof(ILog)) as ILog;

        public WordDictionary()
        {
            Lexic = new Dictionary<char, List<Word>>();
            AddToLexic(typeof(CreateAccountCommand));
            AddToLexic(typeof(LoginCommand));
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
                AddToLexic(synonym, partOfSpeech.ParOfSpeechType);
            }
        }

        private void AddToLexic(string word, WordTypeEnum wordType)
        {
            char startChar = word.TrimStart().FirstOrDefault();
            if(Lexic.ContainsKey(startChar))
            {
                if (Lexic[startChar].Find(item => item.Value == word)==null) //don't add if already there.
                    Lexic[startChar].Add(new Word(word, wordType));
            }
            else
            {
                Lexic.Add(startChar, new List<Word>(){new Word(word, wordType)});
            }
        }
    }
}
