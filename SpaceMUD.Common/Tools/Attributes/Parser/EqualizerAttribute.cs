using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Parser;

namespace SpaceMUD.Common.Tools.Attributes.Parser
{
    public class EqualizerAttribute : PartOfSpeechAttribute
    {
        public EqualizerAttribute(params string[] synonyms) : base(WordTypeEnum.Equalizer, synonyms)
        {
        }

        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
    }
}
