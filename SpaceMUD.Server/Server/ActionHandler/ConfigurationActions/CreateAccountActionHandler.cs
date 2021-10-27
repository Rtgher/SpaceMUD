using SpaceMUD.Base.Interface.ActionHandler;
using SpaceMUD.CommandParser.Base;
using SpaceMUD.Common.Enums.Client.CommandData;
using SpaceMUD.Common.Enums.Client.Commands.Configuration;
using SpaceMUD.Server.Actions;
using SpaceMUD.Server.Base.Interface.Connection;
using SpaceMUD.Server.Connection.Events;

namespace SpaceMUD.Server.ActionHandler.ConfigurationActions
{
    public class CreateAccountActionHandler : IActionHandler
    {
        public bool IsDataComplete { get => _command?.Data.Username!=null&&_command?.Data.UnEncodedPassword!=null; }
        public bool IsActionComplete { get; private set; } = false;
        private CreateAccountCommand _command;

        public MUSAction HandleAction(IConnection conn, MessageReceivedArgs args)
        {
            if (conn.Account != null)
            {
                conn.PrepareUpdate($"You are already logged in as '{conn.Account.Username}'");
            }
            _command = new CreateAccountCommand()
            {
                Data = new CreateAccountCommandData()
            };
            ICommandParser parser = new 
            var tokens = args.Message;
            if (_command.Data.Username == null)
            {

            }

            if (IsDataComplete)
            {
                if (conn.Account != null) IsActionComplete = true;
            }

            return new MUSAction()
            {
                Command = _command
            };
        }
    }
}
