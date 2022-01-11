using MUS.Common.Commands.Configuration;
using MUS.Server.Base.Interface.ActionHandler;
using MUS.Server.Base.Interface.Connection;
using MUS.Server.Server.Actions;
using MUS.Server.Server.Connection.Events;

namespace MUS.Server.Server.ActionHandler.ConfigurationActions
{
    public class CreateAccountActionHandler : IActionHandler
    {
        public bool IsDataComplete { get => _command?.ProcessedData.Username != null && _command?.ProcessedData.UnEncodedPassword != null; }
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
