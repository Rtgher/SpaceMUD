using MUS.Common.Interfaces.EntityInterfaces;
using MUS.Entities.Base;


namespace MUS.Entities.World
{
    public class Location : GameObject, ILocation
    {
        public long Id { get; set; }
    }
}
