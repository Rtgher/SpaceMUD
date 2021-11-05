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

    }
}
