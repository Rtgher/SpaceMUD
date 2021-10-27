using SpaceMUD.Common.Enums.Data.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Parser;

namespace SpaceMUD.Common.Tools.Attributes.Parser
{
    /// <summary>
    /// Declares that the decorated class can be or is a Noun.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum, AllowMultiple = true, Inherited = true)]
        public class NounAttribute : PartOfSpeechAttribute
    {
        public TargetType IsType;
        public NounAttribute(TargetType isType, params string[] synonyms) : base(WordTypeEnum.Noun, synonyms) { }
    }
}
