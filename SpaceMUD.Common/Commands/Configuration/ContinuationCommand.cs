using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Common.Enums.Client.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Commands.Configuration
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
