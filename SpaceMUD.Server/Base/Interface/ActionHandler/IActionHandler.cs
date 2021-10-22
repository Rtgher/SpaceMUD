using SpaceMUD.Server.Actions;
using SpaceMUD.Server.Base.Interface.Connection;
using SpaceMUD.Server.Connection;
using SpaceMUD.Server.Connection.Events;


namespace SpaceMUD.Base.Interface.ActionHandler
{
    public interface IActionHandler
    {
        bool IsDataComplete { get; }
        MUSAction HandleAction(IConnection conn, MessageReceivedArgs args);
        
    }
}
