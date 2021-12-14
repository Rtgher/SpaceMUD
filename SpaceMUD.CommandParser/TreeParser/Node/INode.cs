using SpaceMUD.CommandParser.TreeParser.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.CommandParser.TreeParser.Node
{
    public interface INode
    {
        Word Value
        {
            get;
        }
        INode Parent { get; set; }
        INode Left { get; }
        INode Right { get; }
        //Add a new Node
        INode AddNode(INode node);
        IEnumerable<INode> Traverse(IList<INode> list);

    }
}
