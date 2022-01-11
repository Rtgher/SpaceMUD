using MUS.CommandParser.TreeParser.Base;
using MUS.Common.Commands.Base;

namespace MUS.CommandParser.Base
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string command);
        IWordTree Tree { get; }
    }
}
