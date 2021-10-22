using SpaceMUD.Base.Interface.ActionHandler;
using SpaceMUD.Common.Interfaces;
using SpaceMUD.Server.Base.Interface.Connection;
using SpaceMUD.Server.Connection.Events;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

namespace SpaceMUD.Server.ActionHandler
{
    public class LoginActionHandler : IActionHandler
    {
        private readonly ILog log;
        protected string Username { get; set; } = null;
        protected string PasswordUnEncrypted { get; set; } = null;

        public bool IsDataComplete => !(Username == null || PasswordUnEncrypted == null);
        public LoginActionHandler(ILog log)
        {
            this.log = log;
        }

        public void HandleAction(IConnection conn, MessageReceivedArgs args)
        {
            if (args.Message.Length < 2)
            { log.LogWarning("Received too short a message. Something went wrong."); return; }
            var tokens = args.Message.Split();
            switch (tokens.Length)
            {
                case var expression when (args.Message.Split().Length>=2):
                    int i = 0;
                    while (!IsValidFormat(tokens[i])) { i++; if (i == tokens.Length) break; }
                    if (Username == null)
                    {
                        if (IsValidFormat(tokens[i], new Regex(@"([A-z])\w+")))
                        {
                            Username = tokens[i];
                            conn.PrepareUpdate($"Attempting login with logon '{Username}'");
                            i++;
                            if (i == tokens.Length) break;//if we reach end of tokens for this message we end here.
                        }
                    }
                    
                    if(PasswordUnEncrypted == null)
                    {
                        string password;
                        password = args.Message.Contains(Username)? 
                         args.Message.Substring(args.Message.IndexOf(Username) + Username.Length):args.Message;
                        if (IsValidFormat(password))
                        {
                            PasswordUnEncrypted = password;
                            string hiddenPassword = string.Concat(
                            password.ToCharArray().Select(c => '*'));
                            conn.PrepareUpdate($" and password '{hiddenPassword}'");
                        }
                    }
                        break;
                case 1:
                    if (Username == null)
                    {
                        if (IsValidFormat(tokens.FirstOrDefault()))
                        {
                            Username = tokens.First();
                            conn.PrepareUpdate($"Attempting login with logon '{Username}'");
                            break;
                        }
                        else
                        {
                            conn.PrepareUpdate("Username sent not in valid format.\n\rPlease enter an username of 5 or more characters, containing letters, numbers and underscores ('_') only.");
                            conn.Update();
                            break;
                        }
                    }

                    if (PasswordUnEncrypted == null)
                    {
                        PasswordUnEncrypted = tokens.First();
                        string hiddenPassword = string.Concat(
                            PasswordUnEncrypted.ToCharArray().Select(c => '*'));
                        conn.PrepareUpdate($" and password '{hiddenPassword}'");
                        break;
                    }

                    break;
                default:
                    break;
            }

            conn.Update();
            ///try to retrieve the account from db.
            /// if successful, check the password. if unsuccessful, suggest creating a new account.
            /// set the account to the connection.
        }

        private bool IsValidFormat(string token, Regex allowedFormat = null)
        {
            if (token == null || token==string.Empty) return false;
            if (token.Length <= 4) return false;
            if (allowedFormat != null)
                if (!allowedFormat.IsMatch(token)) return false;

            return true;
        }
    }
}
