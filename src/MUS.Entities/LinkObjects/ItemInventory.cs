using MUS.Common.Interfaces;

namespace MUS.Entities.LinkObjects
{
    public class ItemInventory : IDatabaseObject
    {
        public long ItemId { get; set; }
        public long InventoryId { get; set; }
        public long Id { get; set ; }
    }
}
