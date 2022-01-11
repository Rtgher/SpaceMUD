using MUS.Common.Commands.Base;
using MUS.Common.Enums.Client.Commands;

namespace MUS.Common.Commands.Configuration
{
    public class InvalidCommand : BaseCommand
    {
        public ICommand FailedCommand { get; set; }

        public override CommandsType Type => CommandsType.Configuration;

        public InvalidCommand(ICommand failedCommand)
        {
            FailedCommand = failedCommand;
        }
    }
}
