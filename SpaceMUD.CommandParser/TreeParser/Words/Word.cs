using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Parser;
using SpaceMUD.Common.Tools.Attributes.Parser;

namespace SpaceMUD.CommandParser.TreeParser.Words
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

            return this.PartOfSpeechType == other.PartOfSpeechType && (this.Value == other.Value||this.Attribute.Synonyms.Contains<string>(other.Value));
        }
    }
}
