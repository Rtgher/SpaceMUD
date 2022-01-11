using MUS.Common.Enums.Parser;
using MUS.Common.Tools.Attributes.Parser;
using System;
using System.Linq;

namespace MUS.CommandParser.TreeParser.Words
{
    public class Word
    {
        internal string Value { get; }
        internal WordTypeEnum PartOfSpeechType { get; }
        public PartOfSpeechAttribute Attribute { get; }
        public Word(string value, PartOfSpeechAttribute attribute)
        {
            Value = value;
            PartOfSpeechType = attribute.ParOfSpeechType;
            Attribute = attribute;
        }

        public override bool Equals(object obj)
        {
            if (this == null && obj == null) return true;
            if (this == null || obj == null) return false;
            var other = (Word)obj;

            return PartOfSpeechType == other.PartOfSpeechType && (Value == other.Value || Attribute.Synonyms.Contains<string>(other.Value));
        }
    }
}
