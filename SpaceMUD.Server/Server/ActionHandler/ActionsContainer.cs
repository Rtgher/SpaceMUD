using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Server.ActionHandler.ConfigurationActions;

namespace SpaceMUD.Server.ActionHandler
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
