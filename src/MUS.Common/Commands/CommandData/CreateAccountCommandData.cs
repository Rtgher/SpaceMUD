using MUS.Common.Enums.Data.Functional;
using MUS.Common.Tools.Attributes.Parser;
using MUS.Common.Tools.Attributes.Parser.PropertyAttributes;

namespace MUS.Common.Commands.CommandData
{
    public class CreateAccountCommandData : Base.CommandData
    {
        [Order]
        [Noun(TargetType.DataField, "username", "user", "account", "usrn", "account name", "user name")]
        public string Username { get; set; } = null;

        [Order]
        [Noun(TargetType.DataField, "pass", "password", "pswd")]
        public string UnEncodedPassword { get; set; } = null;

        public CreateAccountCommandData FormatRawData()
        {
            ExtractData(this);
            return this;
        }
    }
}
