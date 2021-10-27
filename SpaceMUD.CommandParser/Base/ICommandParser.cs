using SpaceMUD.CommandParser.TreeParser.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.CommandParser.Base
{
    public interface ICommandParser
    {
        
        void ParseCommand(string command);
    }
}
