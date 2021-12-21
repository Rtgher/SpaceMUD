using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Common.Enums.Client.CommandData;
using SpaceMUD.Common.Enums.Data.Functional;
using SpaceMUD.Common.Tools.Attributes.Parser;
using System;

namespace SpaceMUD.Common.Enums.Client.Commands.Configuration
{
    [Verb(TargetType.DataField, "Create", "createaccount", "create account", "create acc")]
    public class CreateAccountCommand : BaseCommand
    {
        public override CommandsType Type { get; } = CommandsType.Configuration;

        public CreateAccountCommand()
        {
            RawData = new CreateAccountCommandData();
        }

        public CreateAccountCommandData ProcessedData
        {
            get
            {
                if (_processedData==null)
                    _processedData = ((CreateAccountCommandData)RawData).FormatRawData();
                return _processedData;
            }
        }
        private CreateAccountCommandData _processedData = null;
        
    }
}
