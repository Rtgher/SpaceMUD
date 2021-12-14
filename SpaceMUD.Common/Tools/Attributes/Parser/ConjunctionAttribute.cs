
using SpaceMUD.Common.Enums.Parser;

namespace SpaceMUD.Common.Tools.Attributes.Parser
{
    public class ConjunctionAttribute : PartOfSpeechAttribute
    {
        public ConjunctionAttribute(params string[] synonyms) : base(WordTypeEnum.Conjuction, synonyms)
        {
        }
    }
}
