using MUS.Common.Enums.Client;
using MUS.Entities.Actors.Player;
using MUS.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MUS.Entities.Network
{
    /// <summary>
    /// A class to represent an user account. 
    /// Stores information of the account itself, including any characters the account has, last date of login, etc.
    /// </summary>
    public class Account : GameObject
    {
        public string Username { get; private set; }
        public string EncodedPassword { get; private set; }

        public AccountPermissions Permission { get; private set; }
        public IList<PlayerCharacter> Characters { get; private set; }

        public void AddCharacter(PlayerCharacter character)
        {
            Characters.Add(character);
        }

        public void SetPermission(AccountPermissions permission)
        {
            switch (permission)
            {
                case AccountPermissions.Default:
                case AccountPermissions.Member:
                case AccountPermissions.Admin:
                    Permission = permission;
                    break;
                case AccountPermissions.Master:
                    //only I get to be the master <<evil laugh>>.
                    break;
                default:
                    Permission = AccountPermissions.Member;
                    break;

            }
        }

    }
}
