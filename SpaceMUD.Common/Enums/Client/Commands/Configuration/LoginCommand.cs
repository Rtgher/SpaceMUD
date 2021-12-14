using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Common.Enums.Client.CommandData;
using SpaceMUD.Common.Enums.Data.Functional;
using SpaceMUD.Common.Tools.Attributes.Parser;

namespace SpaceMUD.Common.Enums.Client.Commands.Configuration
{
    [Verb(TargetType.Default, "log in", "login")]
    public class LoginCommand : BaseCommand
    {
        public override CommandsType Type { get; } = CommandsType.Configuration;
    }
}
