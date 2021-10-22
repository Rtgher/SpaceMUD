using SpaceMUD.Server.Base.Interface.Connection;
using SpaceMUD.Server.Connection;
using SpaceMUD.Server.Connection.Events;


namespace SpaceMUD.Base.Interface.ActionHandler
{
    public interface IActionHandler
    {
        bool IsDataComplete { get; }
        void HandleAction(IConnection conn, MessageReceivedArgs args);
    }
}
