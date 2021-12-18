using SpaceMUD.CommandParser.TreeParser.Base;
using SpaceMUD.Common.Commands.Base;

namespace SpaceMUD.CommandParser.Base
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string command);
        IWordTree Tree { get; }
    }
}
