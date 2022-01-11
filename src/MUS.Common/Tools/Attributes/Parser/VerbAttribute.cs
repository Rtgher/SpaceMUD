using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUS.Common.Enums.Parser;
using MUS.Common.Enums.Data.Functional;

namespace MUS.Common.Tools.Attributes.Parser
{
    /// <summary>
    /// Declares the decorated class as a verb.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
    public class VerbAttribute : PartOfSpeechAttribute
    {
        public TargetType TargetType;

        public VerbAttribute(TargetType target, params string[] synonyms) : base(WordTypeEnum.Verb, synonyms)
        {
            TargetType = target;
        }
    }
}
