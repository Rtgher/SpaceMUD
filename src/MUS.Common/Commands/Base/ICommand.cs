using MUS.Common.Enums.Client.Commands;

namespace MUS.Common.Commands.Base
{
    public interface ICommand
    {
        CommandsType Type { get; }
        CommandData RawData { get; }
        ICommand FollowUpCommand { get; }
        void AddFollowUpCommand(ICommand command);
        string CommandString { get; set; }
        bool Completed { get; set; }

        void ContinueCommand(ICommand command);
    }
}
