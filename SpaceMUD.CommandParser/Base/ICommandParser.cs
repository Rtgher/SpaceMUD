using SpaceMUD.Common.Commands.Base;

namespace SpaceMUD.CommandParser.Base
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string command);
    }
}
