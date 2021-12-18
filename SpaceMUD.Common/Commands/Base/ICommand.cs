using SpaceMUD.Common.Enums.Client.CommandData;
using SpaceMUD.Common.Enums.Client.Commands;


namespace SpaceMUD.Common.Commands.Base
{
    public interface ICommand
    {
        CommandsType Type { get; }
        CommandData RawData { get; }
        ICommand FollowUpCommand { get; }
        void AddFollowUpCommand(ICommand command);
    }
}
