using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Enums.Client.Commands.Base
{
    public interface ICommand
    {
        public CommandsType Type { get; }
    }
}
