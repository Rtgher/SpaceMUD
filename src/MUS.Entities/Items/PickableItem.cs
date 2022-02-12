using MUS.Entities.Base;
using MUS.Entities.Trait.Descriptive.Base.IDo;
using MUS.Entities.Trait.Functional.Base.ICan;
using MUS.Entities.Trait.Functional.Base.IDo;
using MUS.Common.Enums.Data.Functional;
using MUS.Common.Tools.Attributes.Parser;

namespace MUS.Entities.Items
{
    [Noun(TargetType.PickableItem, "object", "item", "thing")]
    public class PickableItem : Item, ICanBePickedUp
    {
        public IDoBePickedUp DoCanBePickedUp { get; private set; }

        public IWeight Weight { get; private set; }
    }
}
