using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Base.Interface.ActionHandler;
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
            if (args.Account == null) //if linked account is null we need to stop all other actions until we login. 
            {
                if (args.Message.StartsWith("create", StringComparison.InvariantCultureIgnoreCase) || args.Message.StartsWith("create acc", StringComparison.InvariantCultureIgnoreCase))
                {
                    return MapActionsContainersToConnections[conn].CreateAccountActionHandler.HandleAction(conn, args);
                }
                else
                {
                    if (args.Message.StartsWith("login", StringComparison.InvariantCultureIgnoreCase))
                        args.Message = args.Message.Remove(0, 5).TrimStart();
                    if (args.Message.StartsWith("log in", StringComparison.InvariantCultureIgnoreCase))
                        args.Message = args.Message.Remove(0, 6).TrimStart();
                    return MapActionsContainersToConnections[conn].LoginActionHandler.HandleAction(conn, args);
                }
            }

            return null;
        }
    }
}
