using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUS.Common.Enums.Parser;

namespace MUS.Common.Tools.Attributes.Parser
{
    public class AdverbAttribute : PartOfSpeechAttribute
    {
        public AdverbAttribute(params string[] synonyms) : base(WordTypeEnum.Adverb, synonyms)
        {
        }
    }
}
