using MUS.Common.Enums.Parser;

namespace MUS.Common.Tools.Attributes.Parser
{
    public class ConjunctionAttribute : PartOfSpeechAttribute
    {
        public ConjunctionAttribute(params string[] synonyms) : base(WordTypeEnum.Conjuction, synonyms)
        {
        }
    }
}
