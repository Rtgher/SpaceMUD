using SpaceMUD.CommandParser.TreeParser.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.CommandParser.TreeParser.Node;
using SpaceMUD.CommandParser.TreeParser.Words;
using SpaceMUD.Common.Enums.Parser;

namespace SpaceMUD.CommandParser.TreeParser
{
    public class WordTree : IWordTree
    {
        public INode RootNode { get; private set; } = null;

        public void AddValue(Word word)
        {
            INode node = new WordNode(word);
            if(RootNode == null)
            {
                RootNode = node;
            }
            else
            {
                RootNode.AddNode(node);
            }
        }

        public IEnumerable<Word> ParseTree()
        {
            throw new NotImplementedException();
        }

        public INode SearchTree(Word word)
        {
            throw new NotImplementedException();
        }

        public INode SearchTree(WordTypeEnum typeEnum, int count = 1)
        {
            throw new NotImplementedException();
        }
    }
}
