using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUS.Common.Enums.Parser;

namespace MUS.Common.Tools.Attributes.Parser
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
