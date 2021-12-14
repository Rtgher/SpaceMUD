using SpaceMUD.Common.Tools.Attributes.Parser;


namespace SpaceMUD.Common.Enums.Client.CommandData
{
    public class LoginCommandData : Common.Commands.Base.CommandData
    {
        [Noun(Data.Functional.TargetType.DataField, "username", "user", "account", "usrn", "account name", "user name")]
        public string Username { get; set; } = null;
        [Noun(Data.Functional.TargetType.DataField, "pass", "password", "pswd")]
        public string PasswordUnencoded { get; set; } = null;
        public bool CommandSucceeded { get; set; }
        public bool DataComplete => Username != null && PasswordUnencoded != null;
    }
}
