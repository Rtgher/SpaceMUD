using SpaceMUD.CommandParser.TreeParser.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.CommandParser.TreeParser.Node
{
    internal class WordNode
    {
        Word Value { get; set; }
        WordNode Left { get; set; }
        WordNode Right {get;set;}

        public WordNode(Word value)
        {
            Value = value;
        }

        public void AddNode(WordNode node)
        {

        }
    }
}
