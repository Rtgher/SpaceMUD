using MUS.Common.Enums.Data.Functional;
using MUS.Common.Tools.Attributes.Parser;
using MUS.Common.Tools.Attributes.Parser.PropertyAttributes;

namespace MUS.Common.Commands.CommandData
{
    public class LoginCommandData : Base.CommandData
    {
        [Order]
        [Noun(TargetType.DataField, "username", "user", "account", "usrn", "account name", "user name")]
        public string Username { get; set; } = null;
        [Order]
        [Noun(TargetType.DataField, "pass", "password", "pswd")]
        public string PasswordUnencoded { get; set; } = null;
        public bool CommandSucceeded { get; set; }
        public bool DataComplete => Username != null && PasswordUnencoded != null;

        public LoginCommandData FormatRawData()
        {
            ExtractData(this);
            return this;
        }
    }
}
