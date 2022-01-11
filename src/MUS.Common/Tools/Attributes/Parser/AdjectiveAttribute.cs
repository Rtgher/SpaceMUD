using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUS.Common.Enums.Parser;

namespace MUS.Common.Tools.Attributes.Parser
{
    public class AdjectiveAttribute : PartOfSpeechAttribute
    {
        public AdjectiveAttribute(params string[] synonyms) : base(WordTypeEnum.Adjective, synonyms)
        {
        }
    }
}
