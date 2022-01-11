using MUS.Server.Server.ActionHandler.ConfigurationActions;

namespace MUS.Server.Server.ActionHandler
{
    public class ActionsContainer
    {
        public LoginActionHandler LoginActionHandler { get; private set; }
        public CreateAccountActionHandler CreateAccountActionHandler { get; private set; }

        public ActionsContainer()
        {
            LoginActionHandler = new LoginActionHandler();
            CreateAccountActionHandler = new CreateAccountActionHandler();
        }
    }
}
