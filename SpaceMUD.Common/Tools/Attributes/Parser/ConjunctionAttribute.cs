using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Parser;

namespace SpaceMUD.Common.Tools.Attributes.Parser
{
    public class ConjunctionAttribute : PartOfSpeechAttribute
    {
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public ConjunctionAttribute(params string[] synonyms) : base(WordTypeEnum.Conjuction, synonyms)
        {
        }

        public ConjunctionAttribute(string attributeName, string attributeValue, string[] synonyms): this(synonyms)
        {
            AttributeName = attributeName;
            AttributeValue = attributeValue;
        }
    }
}
