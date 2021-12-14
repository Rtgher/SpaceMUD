using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Client.Commands;

namespace SpaceMUD.Common.Commands.Base
{
    public abstract class BaseCommand : ICommand
    {

        public ICommand FollowUpCommand { get; private set; }
        public abstract CommandsType Type { get; }
        public CommandData RawData { get; protected set; } = new CommandData();

        public void AddFollowUpCommand(ICommand command)
        {
            if (FollowUpCommand == null) FollowUpCommand = command;
            else FollowUpCommand.AddFollowUpCommand(command);
        }
    }
}
