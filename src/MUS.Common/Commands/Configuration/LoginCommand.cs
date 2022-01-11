using MUS.Common.Commands.Base;
using MUS.Common.Commands.CommandData;
using MUS.Common.Enums.Client.Commands;
using MUS.Common.Enums.Data.Functional;
using MUS.Common.Tools.Attributes.Parser;

namespace MUS.Common.Commands.Configuration
{
    [Verb(TargetType.DataField, "log in", "login")]
    public class LoginCommand : BaseCommand
    {
        public override CommandsType Type { get; } = CommandsType.Configuration;
        public LoginCommand()
        {
            RawData = new LoginCommandData();
        }

        public LoginCommand(string username, string passwordUnEncrypted, bool isActionComplete)
        {
            this.username = username;
            this.passwordUnEncrypted = passwordUnEncrypted;
            this.isActionComplete = isActionComplete;
        }

        public LoginCommandData ProcessedData
        {
            get
            {
                if (_processedData == null)
                    _processedData = ((LoginCommandData)RawData).FormatRawData();
                return _processedData;
            }
        }
        private LoginCommandData _processedData = null;
        private string username;
        private string passwordUnEncrypted;
        private bool isActionComplete;
    }
}
