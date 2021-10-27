using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Parser;

namespace SpaceMUD.Common.Tools.Attributes.Parser
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public abstract class PartOfSpeechAttribute : Attribute
    {
        public string[] Synonyms;

        public WordTypeEnum ParOfSpeechType { get; }

        public PartOfSpeechAttribute(WordTypeEnum type, params string[] synonyms)
        {
            Synonyms = synonyms.Select(word=> word.ToLower()).ToArray();
        }

    }
}
