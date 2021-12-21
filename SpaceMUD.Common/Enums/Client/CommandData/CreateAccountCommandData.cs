using SpaceMUD.Common.Tools.Attributes.Parser;


namespace SpaceMUD.Common.Enums.Client.CommandData
{
    public class CreateAccountCommandData : Common.Commands.Base.CommandData
    {
        [Noun(Data.Functional.TargetType.DataField, "username", "user", "account", "usrn", "account name",  "user name")]
        public string Username { get; set; } = null;
        [Noun(Data.Functional.TargetType.DataField, "pass", "password", "pswd")]
        public string UnEncodedPassword { get; set; } = null;

        public CreateAccountCommandData FormatRawData()
        {
            var processedData = new CreateAccountCommandData();
            ExtractData(processedData);
            if(Values.ContainsKey(0.ToString()))
            return processedData;
        }
    }
}
