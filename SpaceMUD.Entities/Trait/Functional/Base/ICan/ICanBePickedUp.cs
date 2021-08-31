using SpaceMUD.Entities.Base;
using SpaceMUD.Entities.Trait.Descriptive.Base.ICan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Entities.Trait.Functional.Base.ICan
{
    public interface ICanBePickedUp : IHaveWeight
    {
        GameObject PickUp();
        bool IsPickedUp { get; }
        GameObject IsPickedUpBy { get; }
    }
}
