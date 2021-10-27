using SpaceMUD.CommandParser.Base;
using SpaceMUD.CommandParser.TreeParser.Base;
using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Entities.Network;
using SpaceMUD.Server.Base.Interface.Connection;

namespace SpaceMUD.Server.Actions
{
    public class MUSAction
    {
        public ICommand Command{ get; set; }
        public ICommandParser CommandParser { get; }
        public Account AccountThatRequestedAction { get; set; }

        public MUSAction()
        {
        }

        public MUSAction(ICommandParser Parser)
        {
            CommandParser = Parser;
        }
    }
}
