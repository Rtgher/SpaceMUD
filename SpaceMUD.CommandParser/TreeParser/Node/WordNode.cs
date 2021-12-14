using SpaceMUD.CommandParser.TreeParser.Words;
using SpaceMUD.Common.Exceptions.Parser;
using SpaceMUD.Common.Enums.Parser;
using System.Collections;
using System.Collections.Generic;

namespace SpaceMUD.CommandParser.TreeParser.Node
{
    public class WordNode : INode
    {

        public WordNode(Word value)
        {
            Value = value;
        }
        public WordNode(Word value, WordNode parent) : this(value)
        {
            Parent = parent;
        }

        public Word Value { get; private set; }

        public INode Parent { get; set; }

        public INode Left { get; private set; }

        public INode Right { get; private set; }

        /// <summary>
        /// Adds node followign rules in the tree. 
        /// </summary>
        /// <param name="node">The node to be added.</param>
        /// <returns>The tree root.</returns>
        public INode AddNode(INode node)
        {
            switch (Value.PartOfSpeechType)
            {
                case WordTypeEnum.Verb:
                    switch (node.Value.PartOfSpeechType)
                    {
                        case WordTypeEnum.Verb:
                            throw new InvalidSyntaxException($"Cannot parse two verbs one after the other. Attempted to Parse {node.Value} after {Value}.");
                            break;
                        case WordTypeEnum.Noun:
                        case WordTypeEnum.Adjective:
                        case WordTypeEnum.Preposition:
                            AddToRight(node);
                            break;
                        case WordTypeEnum.Adverb:
                            AddToLeft(node);
                            break;
                        case WordTypeEnum.Conjuction:
                            SetAsParent(node);
                            return Parent;
                            break;
                    }
                    break;
                case WordTypeEnum.Noun:
                    switch (node.Value.PartOfSpeechType)
                    {
                        case WordTypeEnum.Verb:
                        case WordTypeEnum.Noun:
                            AddToRight(node);
                            break;
                        case WordTypeEnum.Adverb:
                        case WordTypeEnum.Adjective:
                        case WordTypeEnum.Preposition:
                            AddToLeft(node);
                            break;
                        case WordTypeEnum.Conjuction:
                            SetAsParent(node);
                            return Parent;
                            break;
                    }
                    break;
                case WordTypeEnum.Adverb:
                    switch (node.Value.PartOfSpeechType)
                    {
                        case WordTypeEnum.Verb:
                        case WordTypeEnum.Noun:
                        case WordTypeEnum.Adverb:
                        case WordTypeEnum.Adjective:
                        case WordTypeEnum.Preposition:
                            AddToRight(node);
                            break;
                        case WordTypeEnum.Conjuction:
                            SetAsParent(node);
                            return Parent;
                            break;
                    }
                    break;
                case WordTypeEnum.Adjective:
                    switch (node.Value.PartOfSpeechType)
                    {
                        case WordTypeEnum.Verb:
                            AddToLeft(node);
                            break;
                        case WordTypeEnum.Noun:
                            AddToRight(node);
                            break;
                        case WordTypeEnum.Adverb:
                            AddToLeft(node);
                            break;
                        case WordTypeEnum.Adjective:
                            AddToRight(node);
                            break;
                        case WordTypeEnum.Preposition:
                            AddToRight(node);
                            break;
                        case WordTypeEnum.Conjuction:
                            SetAsParent(node);
                            break;
                    }
                    break;
                case WordTypeEnum.Preposition:
                    AddToRight(node);
                    break;
                case WordTypeEnum.Conjuction:
                    switch (node.Value.PartOfSpeechType)
                    {
                        case WordTypeEnum.Verb:
                        case WordTypeEnum.Noun:
                        case WordTypeEnum.Adverb:
                        case WordTypeEnum.Adjective:
                        case WordTypeEnum.Preposition:
                            if (Left == null)
                            {
                                AddToLeft(node);
                                break;
                            }
                            if (Right == null)
                            {
                                AddToRight(node);
                                break;
                            }
                            AddToLeft(node);
                            break;
                        case WordTypeEnum.Conjuction:
                            SetAsParent(node);
                            return Parent;
                            break;
                    }
                    break;
            }
            return this;
        }

        private void SetAsParent(INode node)
        {
            if (this.Parent != null) Parent.AddNode(node);
            else Parent = node;

            Parent.AddNode(this);
        }

        private void AddToLeft(INode node)
        {
            if (Left == null)
            {
                node.Parent = this;
                Left = node;
            }
            else Left.AddNode(node);
        }
        private void AddToRight(INode node)
        {
            if (Right == null)
            {
                node.Parent = this;
                Right = node;
            }
            else Right.AddNode(node);
        }

        public IEnumerable<INode> Traverse(IList<INode> list)
        {
            list.Add(this);
            if (Left!=null) Left.Traverse(list);
            if (Right != null) Right.Traverse(list);
            return list;
        }
    }
}