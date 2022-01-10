using System.Collections.Generic;
using SpaceMUD.CommandParser.Base;
using SpaceMUD.Common.Commands.Configuration;
using SpaceMUD.Server.Actions;
using SpaceMUD.Server.Base.Interface.Connection;
using SpaceMUD.Server.Connection.Events;

namespace SpaceMUD.Server.ActionHandler
{
    public class ActionHandlers
    {
        protected Dictionary<IConnection, ActionsContainer> MapActionsContainersToConnections = new Dictionary<IConnection, ActionsContainer>();
        
        public ActionHandlers()
        {
            
        }

        public void AddConnection(IConnection conn)
        {
            MapActionsContainersToConnections.Add(conn, new ActionsContainer());
        }

        public MUSAction Delegate(IConnection conn, MessageReceivedArgs args)
        {
            ICommandParser parser = CommandParser.Dependency.DependencyContainer.Provider.GetService(typeof(ICommandParser)) as ICommandParser;
            var command = parser.ParseCommand(args.Message);

            if (args.Account == null) //if linked account is null we need to stop all other actions until we login. 
            {
                if (command is CreateAccountCommand)
                {
                    return MapActionsContainersToConnections[conn].CreateAccountActionHandler.HandleAction(conn, args);
                }
                
                if(command is LoginCommand)
                {
                    return MapActionsContainersToConnections[conn].LoginActionHandler.HandleAction(conn, args);
                }
            }

            if (conn.IsExecutingACommand)
            {
                if(command is ContinuationCommand)
                {
                   conn.ExecutingCommand.ContinueCommand(command);
                }else if(conn.ExecutingCommand.Type == command.Type)
                {
                    conn.ExecutingCommand.ContinueCommand(command);    
                }
            }
            return null;
        }
    }
}
