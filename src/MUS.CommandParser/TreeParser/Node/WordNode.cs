using MUS.CommandParser.TreeParser.Words;
using MUS.Common.Enums.Parser;
using MUS.Common.Exceptions.Parser;
using System.Collections.Generic;

namespace MUS.CommandParser.TreeParser.Node
{
    public class WordNode : INode
    {

        public WordNode(Word value)
        {
            Content = value;
        }
        public WordNode(Word value, WordNode parent) : this(value)
        {
            Parent = parent;
        }

        public Word Content { get; private set; }

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
            switch (Content.PartOfSpeechType)
            {
                case WordTypeEnum.Verb:
                    switch (node.Content.PartOfSpeechType)
                    {
                        case WordTypeEnum.Verb:
                            throw new InvalidSyntaxException($"Cannot parse two verbs one after the other. Attempted to Parse {node?.Content?.Value} after {Content?.Value}.");
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
                        case WordTypeEnum.Equalizer:
                            AddToRight(node);
                            break;
                    }
                    break;
                case WordTypeEnum.Noun:
                    switch (node.Content.PartOfSpeechType)
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
                        case WordTypeEnum.Equalizer:
                            SetAsParent(node);
                            return Parent;
                    }
                    break;
                case WordTypeEnum.Adverb:
                    switch (node.Content.PartOfSpeechType)
                    {
                        case WordTypeEnum.Verb:
                            SetAsParent(node);
                            return Parent;
                        case WordTypeEnum.Noun:
                        case WordTypeEnum.Adverb:
                        case WordTypeEnum.Adjective:
                        case WordTypeEnum.Preposition:
                            AddToRight(node);
                            break;
                        case WordTypeEnum.Conjuction:
                        case WordTypeEnum.Equalizer:
                            SetAsParent(node);
                            return Parent;
                    }
                    break;
                case WordTypeEnum.Adjective:
                    switch (node.Content.PartOfSpeechType)
                    {
                        case WordTypeEnum.Verb:
                            AddToRight(node);
                            break;
                        case WordTypeEnum.Noun:
                            if (Parent != null && (Parent.Content.PartOfSpeechType == WordTypeEnum.Equalizer || Parent.Content.PartOfSpeechType == WordTypeEnum.Noun))
                                AddToRight(node);
                            else SetAsParent(node);
                            return Parent;
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
                        case WordTypeEnum.Equalizer:
                            if (Parent != null && Parent.Content.PartOfSpeechType == WordTypeEnum.Equalizer)
                            {
                                AddToRight(node);
                            }
                            else
                                SetAsParent(node);
                            break;
                    }
                    break;
                case WordTypeEnum.Preposition:
                    switch (node.Content.PartOfSpeechType)
                    {
                        case WordTypeEnum.Verb:
                        case WordTypeEnum.Noun:
                        case WordTypeEnum.Adverb:
                        case WordTypeEnum.Adjective:
                        case WordTypeEnum.Preposition:
                            AddToRight(node);
                            break;
                        case WordTypeEnum.Conjuction:
                            throw new InvalidSyntaxException("Cannot have a Conjunction after a preposition!");
                        case WordTypeEnum.Equalizer:
                            throw new InvalidSyntaxException("Cannot have an equalizer symbol after a preposition!");
                    }
                    break;
                case WordTypeEnum.Conjuction:
                    switch (node.Content.PartOfSpeechType)
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
                        case WordTypeEnum.Equalizer:
                            throw new InvalidSyntaxException("Cannot have an equalizer symbol after a conjunction!");
                    }
                    break;
                case WordTypeEnum.Equalizer:
                    switch (node.Content.PartOfSpeechType)
                    {
                        case WordTypeEnum.Verb:
                        case WordTypeEnum.Noun:
                        case WordTypeEnum.Adverb:
                        case WordTypeEnum.Adjective:
                        case WordTypeEnum.Preposition:
                            if (Left == null || Left.Content.PartOfSpeechType == WordTypeEnum.Preposition && Left.Right == null) AddToLeft(node);
                            else AddToRight(node);
                            break;
                        case WordTypeEnum.Conjuction:
                            if (Right != null) { Right.AddNode(node); break; }
                            throw new InvalidSyntaxException("Cannot have an conjunction after an equalizer symbol!");
                        case WordTypeEnum.Equalizer:
                            if (Right != null)
                            {
                                Right.AddNode(node);
                                break;
                            }
                            throw new InvalidSyntaxException("Cannot have an equalizer symbol after an equalizer symbol! Expecting full 'item=value' syntax!'");
                    }
                    break;
            }
            return this;
        }

        private void SetAsParent(INode node)
        {

            if (Parent != null)
            {
                var oldParent = Parent;
                oldParent.Remove(this);
                Parent = node;
                oldParent.AddNode(node);
            }
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
            if (Left != null) Left.Traverse(list);
            if (Right != null) Right.Traverse(list);
            return list;
        }

        public bool Remove(INode wordNode)
        {
            if (Left == wordNode)
            {
                Left = null;
                return true;
            }
            if (Right == wordNode)
            {
                Right = null;
                return true;
            }
            if (Left != null && Left.Remove(wordNode)) return true;
            if (Right != null && Right.Remove(wordNode)) return true;

            return false;
        }
    }
}