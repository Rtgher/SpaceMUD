using MUS.Common.Commands.Base;
using MUS.Common.Enums.Client.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUS.Common.Commands.Configuration
{
    public class ContinuationCommand : BaseCommand
    {
        public override CommandsType Type => CommandsType.Configuration;
        public ContinuationCommand()
        {
            RawData = new();
        }
    }
}
