﻿using SpaceMUD.Entities.Trait.Descriptive.Base.IDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Entities.Trait.Descriptive.Base.ICan
{
    interface IHaveWeight
    {
        IWeight Weight { get; }
    }
}
