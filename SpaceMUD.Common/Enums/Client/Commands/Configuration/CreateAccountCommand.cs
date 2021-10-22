using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Common.Enums.Client.CommandData;

namespace SpaceMUD.Common.Enums.Client.Commands.Configuration
{
    public class CreateAccountCommand : ICommand
    {
        public CreateAccountCommandData Data { get; set; }

        public CommandsType Type { get; } = CommandsType.Configuration;
    }
}
