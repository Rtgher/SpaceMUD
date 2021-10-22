﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Enums.Client.CommandData
{
    public class LoginCommandData : Common.Commands.Base.CommandData
    {
        public string Username { get; set; } = null;
        public string PasswordUnencoded { get; set; } = null;
        public bool CommandSucceeded { get; set; }
        public bool DataComplete => Username != null && PasswordUnencoded != null;
    }
}