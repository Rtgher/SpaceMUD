using MUS.Common.Interfaces;

namespace MUS.Entities.Base
{
    public class Entity : GameObject, IDatabaseObject
    {
        public long Id { get; set; }
    }
}
