using MUS.Server.Base.Interface.Connection;
using MUS.Server.Server.Actions;
using MUS.Server.Server.Connection.Events;


namespace MUS.Server.Base.Interface.ActionHandler
{
    public interface IActionHandler
    {
        bool IsDataComplete { get; }
        MUSAction HandleAction(IConnection conn, MessageReceivedArgs args);

    }
}
