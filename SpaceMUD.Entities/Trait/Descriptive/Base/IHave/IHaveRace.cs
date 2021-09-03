using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Entities.Trait.Descriptive.Races;

namespace SpaceMUD.Entities.Trait.Descriptive.Base.IHave
{
    public interface IHaveRace
    {
        Race Race { get; }
    }
}
