using MUS.Common.Interfaces;
using MUS.Common.Tools.Attributes.Parser;

namespace MUS.Entities.Storage
{
    [Noun(Common.Enums.Data.Functional.TargetType.Menu, "inventory", "i")]
    public class Inventory : IDatabaseObject
    {
        public long Id { get; set; }
        /// <summary>
        /// Points to the entity that 'owns' this inventory.
        /// </summary>
        public long EntityId { get; set; }
    }
}
