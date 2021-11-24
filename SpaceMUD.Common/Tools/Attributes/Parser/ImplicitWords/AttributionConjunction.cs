using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Tools.Attributes.Parser.ImplicitWords
{
    [Conjunction(Synonyms = new string[]{":","=", "-"})]
    public class AttributionConjunction
    {
    }
}
