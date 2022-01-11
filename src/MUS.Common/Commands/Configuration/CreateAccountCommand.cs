using MUS.Common.Commands.Base;
using MUS.Common.Commands.CommandData;
using MUS.Common.Enums.Client.Commands;
using MUS.Common.Enums.Data.Functional;
using MUS.Common.Tools.Attributes.Parser;
using System;

namespace MUS.Common.Commands.Configuration
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
                if (_processedData == null)
                    _processedData = ((CreateAccountCommandData)RawData).FormatRawData();
                return _processedData;
            }
        }
        private CreateAccountCommandData _processedData = null;

    }
}
