using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUS.Entities.Trait.Descriptive.Races;

namespace MUS.Entities.Trait.Descriptive.Base.IHave
{
    public interface IHaveRace
    {
        Race Race { get; }
    }
}
