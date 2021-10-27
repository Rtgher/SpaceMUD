using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Parser;

namespace SpaceMUD.CommandParser.TreeParser.Words
{
    public class Word
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
