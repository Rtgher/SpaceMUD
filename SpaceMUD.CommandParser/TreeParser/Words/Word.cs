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
        internal string Value { get; }
        internal WordTypeEnum PartOfSpeechType { get; }

        public Word(string value, WordTypeEnum wordType)
        {
            Value = value;
            PartOfSpeechType = wordType;
        }
    }
}
