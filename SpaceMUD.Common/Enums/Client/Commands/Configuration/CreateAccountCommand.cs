using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Common.Enums.Client.CommandData;
using SpaceMUD.Common.Enums.Data.Functional;
using SpaceMUD.Common.Tools.Attributes.Parser;
using System;

namespace SpaceMUD.Common.Enums.Client.Commands.Configuration
{
    [Verb(TargetType.Default, "Create", "createaccount")]
    public class CreateAccountCommand : ICommand
    {
        public CommandsType Type { get; } = CommandsType.Configuration;
        public Common.Commands.Base.CommandData RawData { get; set; } = new CreateAccountCommandData();
        public CreateAccountCommandData ProcessedData
        {
            get =>((CreateAccountCommandData) RawData).FormatRawData();
        }
        private CreateAccountCommandData _processedData = null;
        

        
    }
}
