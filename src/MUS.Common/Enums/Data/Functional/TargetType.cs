using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUS.Common.Enums.Data.Functional
{
    [Flags]
    public enum TargetType
    {
        DataField = 0,
        Item = 1,
        PickableItem = 2,
        Actor = 4,
        Weapon = 8,
        Consumable = 16,
        Vehicle = 32

    }
}
