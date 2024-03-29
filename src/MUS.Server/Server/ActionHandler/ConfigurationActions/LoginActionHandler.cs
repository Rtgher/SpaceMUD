﻿using Microsoft.Extensions.DependencyInjection;
using MUS.Common.Commands.Configuration;
using MUS.Common.Dependency;
using MUS.Common.Interfaces;
using MUS.Common.Tools;
using MUS.Entities.Network;
using MUS.Server.Base.Interface.ActionHandler;
using MUS.Server.Base.Interface.Connection;
using MUS.Server.Server.Actions;
using MUS.Server.Server.Connection.Events;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MUS.Server.Server.ActionHandler.ConfigurationActions
{
    public class LoginActionHandler : IActionHandler
    {
        private readonly ILog Log;
        protected string Username { get; set; } = null;
        protected string PasswordUnEncrypted { get; set; } = null;

        public bool IsDataComplete => !(Username == null || PasswordUnEncrypted == null);
        private bool IsActionComplete { get; set; } = false;
        private bool FoundAccount = false;

        public LoginActionHandler()
        {
            Log = DependencyContainer.Provider.GetService<ILog>();
        }

        public MUSAction HandleAction(IConnection conn, MessageReceivedArgs args)
        {
            if (args.Message.Length < 2)
            {
                Log.LogWarning("Received too short a message. Something went wrong."); return new MUSAction()
                {
                    Command = new LoginCommand(null, null, false)
                };
            }
            var tokens = args.Message.Split();
            ExtractDataFromMessage(conn, args, tokens);

            conn.Update();
            if (!IsDataComplete)
                return new MUSAction()
                {
                    Command = new LoginCommand(Username, PasswordUnEncrypted, false)
                };

            var connectionAccount = RetrieveAccountFromDatabase(conn);
            if (!FoundAccount)
            {
                conn.PrepareUpdate($"Account '{Username}' not found. If you'd like to create a new account, type the keyword 'create' followed by the account name and password, separated by spaces.");
            }
            conn.Update();
            conn.Account = connectionAccount;
            return new MUSAction()
            {
                Command = new LoginCommand(Username, PasswordUnEncrypted, IsActionComplete)
            };
        }

        private Account RetrieveAccountFromDatabase(IConnection conn)
        {
            var accounts = MUS.Database.Repositor.Repos.Account.GetAll();
            foreach (var account in accounts)
            {
                if (account.Username.Equals(Username, StringComparison.InvariantCultureIgnoreCase))
                {
                    FoundAccount = true;
                    Log.LogInfo($"Found account match for {Username}");
                    if (PasswordUnEncrypted.Equals(PasswordEncryptionHelper.DecodeFrom64(account.EncodedPassword)))
                    {
                        Log.LogInfo("Login succeeded.");
                        IsActionComplete = true;
                        conn.PrepareUpdate($"Connection succcesful. Welcome back {Username}!");
                        return account;
                    }
                    else
                    {
                        conn.PrepareUpdate("Invalid password. Please try again. Enter just the password in your next message, followed by the key 'Enter'.");
                        PasswordUnEncrypted = string.Empty;
                    }
                }
            }

            return null;
        }

        private void ExtractDataFromMessage(IConnection conn, MessageReceivedArgs args, string[] tokens)
        {
            switch (tokens.Length)
            {
                case var expression when args.Message.Split().Length >= 2:
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

                    if (PasswordUnEncrypted == null)
                    {
                        string password;
                        password = args.Message.Contains(Username) ?
                         args.Message.Substring(args.Message.IndexOf(Username) + Username.Length) : args.Message;
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
        }

        private bool IsValidFormat(string token, Regex allowedFormat = null)
        {
            if (token == null || token == string.Empty) return false;
            if (token.Length <= 4) return false;
            if (allowedFormat != null)
                if (!allowedFormat.IsMatch(token)) return false;

            return true;
        }
    }
}
