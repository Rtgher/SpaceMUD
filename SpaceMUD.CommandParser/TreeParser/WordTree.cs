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
            return SearchWords(RootNode, word);
        }

        public INode SearchTree(WordTypeEnum typeEnum, int count = 1)
        {
            int actualCount = 0;
            return SearchWords(RootNode, typeEnum, count, ref actualCount);
        }

        private INode SearchWords(INode node, WordTypeEnum typeEnum, int count, ref int actualCount)
        {
            if (node.Value == null) return null;
            if (node.Value.PartOfSpeechType == typeEnum)
            {
                actualCount++;
                if (actualCount == count) return node;
                
            }
            if (node.Left != null)
            {
                var returnedLeft = SearchWords(node.Left, typeEnum, count, ref actualCount);
                if (returnedLeft != null) return returnedLeft;
            }
            if(node.Right != null)
            {
                var returnedRight = SearchWords(node.Right, typeEnum, count, ref actualCount);
                if (returnedRight != null) return returnedRight;
            }
            return null;
        }

        private INode SearchWords(INode node, Word word)
        {
            if (node.Value == null) return null;
            if (node.Value.Equals(word)) return node;
            if (node.Left != null)
            {
                var returnLeft = SearchWords(node.Left, word);
                if (returnLeft != null) return returnLeft;
            }
            if(node.Right != null)
            {
                var returnRight = SearchWords(node.Right, word);
                if (returnRight != null) return returnRight;
            }

            return null;
        }
    }
}
