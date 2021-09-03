using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Tools.Attributes.Parser
{
    public class AdverbAttribute : PartOfSpeechAttribute
    {
        public AdverbAttribute(string value, params string[] synonyms) : base(value, synonyms)
        {
        }
    }
}
