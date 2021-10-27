using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Common.Enums.Client.CommandData;
using SpaceMUD.Common.Enums.Data.Functional;
using SpaceMUD.Common.Tools.Attributes.Parser;

namespace SpaceMUD.Common.Enums.Client.Commands.Configuration
{
    [Verb(TargetType.Default, "Create", "createaccount")]
    public class CreateAccountCommand : ICommand
    {
        public CreateAccountCommandData Data { get; set; }

        public CommandsType Type { get; } = CommandsType.Configuration;
    }
}
