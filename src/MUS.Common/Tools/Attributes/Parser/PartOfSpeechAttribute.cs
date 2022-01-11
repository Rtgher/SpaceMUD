using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUS.Common.Enums.Parser;

namespace MUS.Common.Tools.Attributes.Parser
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public abstract class PartOfSpeechAttribute : Attribute
    {
        public string[] Synonyms;

        public WordTypeEnum ParOfSpeechType { get; private set; }

        public PartOfSpeechAttribute(WordTypeEnum type, params string[] synonyms)
        {
            ParOfSpeechType = type;
            Synonyms = synonyms.Select(word => word.ToLower()).ToArray();
        }

    }
}
