using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Enums.Client.CommandData
{
    public class CreateAccountCommandData : Common.Commands.Base.CommandData
    {
        public string Username { get; set; } = null;
        public string UnEncodedPassword { get; set; } = null;

    }
}
