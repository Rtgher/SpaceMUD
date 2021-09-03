using SpaceMUD.CommandParser.TreeParser.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.CommandParser.TreeParser.Node
{
    internal interface INode
    {
        Word Value
        {
            get;
        }
        WordNode Parent { get; }
        WordNode Left { get; }
        WordNode Right { get; }
        //Add a new Node
        WordNode AddNode(WordNode node);

    }
}
