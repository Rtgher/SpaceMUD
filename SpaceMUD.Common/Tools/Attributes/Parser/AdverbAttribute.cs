using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Parser;

namespace SpaceMUD.Common.Tools.Attributes.Parser
{
    public class AdverbAttribute : PartOfSpeechAttribute
    {
        public AdverbAttribute(params string[] synonyms) : base(WordTypeEnum.Adverb, synonyms)
        {
        }
    }
}
