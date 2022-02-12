using MUS.Common.Tools.Attributes.Parser;
using MUS.Entities.Base;


namespace MUS.Entities.Storage
{
    [Noun(Common.Enums.Data.Functional.TargetType.PickableItem, "chest", "vault", "box", "crate", "coffer", "container")]
    public class Chest : Entity
    {
        public long KeyEntityId { get; set; }
        public bool IsLocked { get; set; }
        
    }
}
