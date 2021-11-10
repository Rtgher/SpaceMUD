using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.CommandParser.Base;
using SpaceMUD.CommandParser.Dictionary;

namespace SpaceMUD.CommandParser.TreeParser
{
    public class TreeParser : ICommandParser
    {
        public WordDictionary Lexic { get; }

        public TreeParser(WordDictionary lexic)
        {

        }
        public void ParseCommand(string command)
        {
            throw new NotImplementedException();
        }
    }
}
