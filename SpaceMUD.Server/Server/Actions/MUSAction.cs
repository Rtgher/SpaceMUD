using SpaceMUD.CommandParser.Base;
using SpaceMUD.CommandParser.TreeParser.Base;
using SpaceMUD.Common.Commands.Base;

namespace SpaceMUD.Server.Actions
{
    public class MUSAction
    {
        public ICommand Command{ get; set; }
        public ICommandParser CommandParser { get; }
    }
}
