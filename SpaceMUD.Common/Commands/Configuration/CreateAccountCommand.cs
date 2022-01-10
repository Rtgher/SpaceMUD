using SpaceMUD.Common.Commands.Base;
using SpaceMUD.Common.Commands.CommandData;
using SpaceMUD.Common.Enums.Client.Commands;
using SpaceMUD.Common.Enums.Data.Functional;
using SpaceMUD.Common.Tools.Attributes.Parser;
using System;

namespace SpaceMUD.Common.Commands.Configuration
{
    [Verb(TargetType.DataField, "Create", "createaccount", "create account", "create acc")]
    public class CreateAccountCommand : BaseCommand
    {
        public override CommandsType Type { get; } = CommandsType.Configuration;

        public CreateAccountCommand()
        {
            RawData = new CommandData.CreateAccountCommandData();
        }

        public CommandData.CreateAccountCommandData ProcessedData
        {
            get
            {
                if (_processedData == null)
                    _processedData = ((CreateAccountCommandData)RawData).FormatRawData();
                return _processedData;
            }
        }
        private CommandData.CreateAccountCommandData _processedData = null;

    }
}
