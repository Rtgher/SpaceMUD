using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUS.Common.Interfaces.EntityInterfaces
{
    public interface IGameObject
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
