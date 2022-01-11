using MUS.CommandParser.Base;
using MUS.Common.Commands.Base;
using MUS.Entities.Network;

namespace MUS.Server.Server.Actions
{
    public class MUSAction
    {
        public ICommand Command { get; set; }
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
