using MUS.CommandParser.TreeParser.Words;
using System.Collections.Generic;

namespace MUS.CommandParser.TreeParser.Node
{
    public interface INode
    {
        Word Content
        {
            get;
        }
        INode Parent { get; set; }
        INode Left { get; }
        INode Right { get; }
        //Add a new Node
        INode AddNode(INode node);
        IEnumerable<INode> Traverse(IList<INode> list);
        bool Remove(INode wordNode);
    }
}
