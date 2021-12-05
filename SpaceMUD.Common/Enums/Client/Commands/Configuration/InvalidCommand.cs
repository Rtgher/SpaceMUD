using SpaceMUD.Common.Commands.Base;

namespace SpaceMUD.Common.Enums.Client.Commands.Configuration
{
    public class InvalidCommand : ICommand
    {
        public ICommand FailedCommand { get; set; }

        public CommandsType Type => CommandsType.Configuration;

        public Common.Commands.Base.CommandData RawData { get; set; }

        public InvalidCommand(ICommand failedCommand)
        {
            FailedCommand = failedCommand;
        }
    }
}
