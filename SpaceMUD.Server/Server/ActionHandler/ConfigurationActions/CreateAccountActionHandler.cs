using SpaceMUD.Base.Interface.ActionHandler;
using SpaceMUD.CommandParser.Base;
using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Common.Enums.Client.CommandData;
using SpaceMUD.Common.Enums.Client.Commands.Configuration;
using SpaceMUD.Server.Actions;
using SpaceMUD.Server.Base.Interface.Connection;
using SpaceMUD.Server.Connection.Events;

namespace SpaceMUD.Server.ActionHandler.ConfigurationActions
{
    public class CreateAccountActionHandler : IActionHandler
    {
        public bool IsDataComplete { get => _command?.ProcessedData.Username!=null&&_command?.ProcessedData.UnEncodedPassword!=null; }
        public bool IsActionComplete { get; private set; } = false;
        private CreateAccountCommand _command;

        public MUSAction HandleAction(IConnection conn, MessageReceivedArgs args)
        {
            _command = new CreateAccountCommand();

            if (conn.Account != null)
            {
                conn.PrepareUpdate($"You are already logged in as '{conn.Account.Username}'");
                return new MUSAction()
                {
                    Command = new InvalidCommand(_command),
                    AccountThatRequestedAction = conn.Account
                };
            }
            ICommandParser parser = CommandParser.Dependency.DependencyContainer.Provider.GetService(typeof(ICommandParser)) as ICommandParser;
            //TODO: Implement getting data from ICommandParser.

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
