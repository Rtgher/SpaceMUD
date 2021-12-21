using SpaceMUD.Common.Tools.Attributes.Parser;
using SpaceMUD.Common.Tools.Attributes.Parser.PropertyAttributes;

namespace SpaceMUD.Common.Enums.Client.CommandData
{
    public class CreateAccountCommandData : Common.Commands.Base.CommandData
    {
        [Order]
        [Noun(Data.Functional.TargetType.DataField, "username", "user", "account", "usrn", "account name",  "user name")]
        public string Username { get; set; } = null;

        [Order]
        [Noun(Data.Functional.TargetType.DataField, "pass", "password", "pswd")]
        public string UnEncodedPassword { get; set; } = null;

        public CreateAccountCommandData FormatRawData()
        {
            ExtractData(this);
            return this;
        }
    }
}
