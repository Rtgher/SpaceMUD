using SpaceMUD.Common.Commands.Base;

namespace SpaceMUD.Common.Enums.Client.Commands.Configuration
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
