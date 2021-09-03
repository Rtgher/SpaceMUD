using SpaceMUD.CommandParser.TreeParser.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.CommandParser.TreeParser.Words
{
    internal class Word
    {
        string Value { get; }
        WordTypeEnum PartOfSpeechType { get; }

        public Word(string value, WordTypeEnum wordType)
        {
            Value = value;
            PartOfSpeechType = wordType;
        }
    }
}
