using MUS.Common.Interfaces;
using MUS.Entities.Base;

namespace MUS.Entities.Items
{
    public class Item : GameObject, IDatabaseObject
    {
        public long Id { get; set; }
    }
}
