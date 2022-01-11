using MUS.Entities.Trait.Functional.Base.IDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUS.Entities.Trait.Functional.Base.ICan
{
    public interface ICanFight
    {
        IDoFight DoFight { get; }
    }
}
