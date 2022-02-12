
using MUS.Common.Interfaces;

namespace MUS.Entities.LinkObjects
{
    public class EntityLocation : IDatabaseObject
    {
        public long EntityId { get; set; }
        public long LocationId { get; set; }
        public long Id { get; set; }
    }
}
