using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Parser;

namespace SpaceMUD.Common.Tools.Attributes.Parser
{
    public class AdjectiveAttribute : PartOfSpeechAttribute
    {
        public AdjectiveAttribute(params string[] synonyms) : base(WordTypeEnum.Adjective, synonyms)
        {
        }
    }
}
