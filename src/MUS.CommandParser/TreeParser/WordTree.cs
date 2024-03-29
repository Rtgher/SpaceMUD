﻿using MUS.CommandParser.TreeParser.Base;
using MUS.CommandParser.TreeParser.Node;
using MUS.CommandParser.TreeParser.Words;
using MUS.Common.Enums.Parser;
using System.Collections;
using System.Collections.Generic;

namespace MUS.CommandParser.TreeParser
{
    public class WordTree : IWordTree
    {
        public INode RootNode { get; private set; } = null;
        private bool _modified = false;
        private IEnumerable<INode> _nodes;

        public void AddValue(Word word)
        {
            _modified = true;
            INode node = new WordNode(word);
            if (RootNode == null)
            {
                RootNode = node;
            }
            else
            {
                RootNode.AddNode(node);
            }
        }

        public IEnumerator<INode> GetEnumerator()
        {
            return ParseTree().GetEnumerator();
        }

        public IEnumerable<INode> ParseTree()
        {
            if (_modified)
            {
                List<INode> nodes = new List<INode>();
                _nodes = RootNode.Traverse(nodes);
            }
            return _nodes;
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ParseTree().GetEnumerator();
        }

        private INode SearchWords(INode node, WordTypeEnum typeEnum, int count, ref int actualCount)
        {
            if (node.Content == null) return null;
            if (node.Content.PartOfSpeechType == typeEnum)
            {
                actualCount++;
                if (actualCount == count) return node;

            }
            if (node.Left != null)
            {
                var returnedLeft = SearchWords(node.Left, typeEnum, count, ref actualCount);
                if (returnedLeft != null) return returnedLeft;
            }
            if (node.Right != null)
            {
                var returnedRight = SearchWords(node.Right, typeEnum, count, ref actualCount);
                if (returnedRight != null) return returnedRight;
            }
            return null;
        }

        private INode SearchWords(INode node, Word word)
        {
            if (node.Content == null) return null;
            if (node.Content.Equals(word)) return node;
            if (node.Left != null)
            {
                var returnLeft = SearchWords(node.Left, word);
                if (returnLeft != null) return returnLeft;
            }
            if (node.Right != null)
            {
                var returnRight = SearchWords(node.Right, word);
                if (returnRight != null) return returnRight;
            }

            return null;
        }

        public IEnumerable<INode> GetParts(WordTypeEnum wordType)
        {
            var nodes = ParseTree();
            var parts = new List<INode>();

            foreach (var leaf in nodes)
            {
                if (leaf.Content.PartOfSpeechType == wordType)
                {
                    parts.Add(leaf);
                }
            }

            return parts;
        }

        public int Count()
        {
            var list = new List<INode>();
            var nodes = RootNode?.Traverse(list);

            return list.Count;
        }
    }
}
