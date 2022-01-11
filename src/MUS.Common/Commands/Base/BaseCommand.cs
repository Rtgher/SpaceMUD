using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUS.Common.Enums.Client.Commands;

namespace MUS.Common.Commands.Base
{
    public abstract class BaseCommand : ICommand
    {

        public ICommand FollowUpCommand { get; private set; }
        public abstract CommandsType Type { get; }
        public CommandData RawData { get; protected set; }
        public string CommandString { get; set; }
        public bool Completed { get => _completed && (FollowUpCommand?.Completed ?? true); set => _completed = value; }
        private bool _completed = false;

        public void AddFollowUpCommand(ICommand command)
        {
            if (FollowUpCommand == null) FollowUpCommand = command;
            else FollowUpCommand.AddFollowUpCommand(command);
        }

        public void ContinueCommand(ICommand command)
        {
            RawData.AppendData(command.RawData);
        }

    }
}
