using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Common.Enums.Client.CommandData;

namespace SpaceMUD.Common.Enums.Client.Commands.Configuration
{
    public class LoginCommand : ICommand
    {
        public CommandsType Type { get; } = CommandsType.Configuration;
        public LoginCommandData Data { get; set; }
    }
}
