using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Tools.Attributes.Parser
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public abstract class PartOfSpeechAttribute : Attribute
    {
        /// <summary>
        /// String value of the Part of Speech. This is the decorated object's string representation.
        /// </summary>
        public string Value;

        public string[] Synonyms;

        public PartOfSpeechAttribute(string value, params string[] synonyms)
        {
            Value = value.ToLower();
            Synonyms = synonyms.Select(word=> word.ToLower()).Append(value).ToArray();
        }

    }
}
