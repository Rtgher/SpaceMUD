using SpaceMUD.Base.Interface.ActionHandler;
using SpaceMUD.Common.Commands.Configuration;
using SpaceMUD.Server.Actions;
using SpaceMUD.Server.Base.Interface.Connection;
using SpaceMUD.Server.Connection.Events;

namespace SpaceMUD.Server.ActionHandler.ConfigurationActions
{
    public class CreateAccountActionHandler : IActionHandler
    {
        public bool IsDataComplete { get => _command?.ProcessedData.Username!=null && _command?.ProcessedData.UnEncodedPassword!=null; }
        public bool IsActionComplete { get; private set; } = false;
        private CreateAccountCommand _command;

        public MUSAction HandleAction(IConnection conn, MessageReceivedArgs args)
        {
            _command = new CreateAccountCommand();

            if (conn.Account != null)
            {
                conn.PrepareUpdate($"You are already logged in as '{conn.Account.Username}'. Please logout first to create a new account.");
                return new MUSAction()
                {
                    Command = new InvalidCommand(_command),
                    AccountThatRequestedAction = conn.Account
                };
            }


            var tokens = args.Message;
            if (_command.ProcessedData.Username == null)
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
