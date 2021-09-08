using SpaceMUD.CommandParser.TreeParser.Words;
using SpaceMUD.Common.Exceptions.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.CommandParser.TreeParser.Node
{
    internal class WordNode : INode
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

        public WordNode Parent { get; set; }

        public WordNode Left { get; private set; }

        public WordNode Right { get; private set; }

        /// <summary>
        /// Adds node followign rules in the tree. 
        /// </summary>
        /// <param name="node">The node to be added.</param>
        /// <returns>The tree root.</returns>
        public WordNode AddNode(WordNode node)
        {
            switch (Value.PartOfSpeechType)
            {
                case Enums.WordTypeEnum.Verb:
                    switch (node.Value.PartOfSpeechType)
                    {
                        case Enums.WordTypeEnum.Verb:
                            throw new InvalidSyntaxException($"Cannot parse two verbs one after the other. Attempted to Parse {node.Value} after {Value}.");
                            break;
                        case Enums.WordTypeEnum.Noun:
                        case Enums.WordTypeEnum.Adjective:
                        case Enums.WordTypeEnum.Preposition:
                            AddToRight(node);
                            break;
                        case Enums.WordTypeEnum.Adverb:
                            AddToLeft(node);
                            break;
                        case Enums.WordTypeEnum.Conjuction:
                            SetAsParent(node);
                            return Parent;
                            break;
                    }
                    break;
                case Enums.WordTypeEnum.Noun:
                    switch (node.Value.PartOfSpeechType)
                    {
                        case Enums.WordTypeEnum.Verb:
                        case Enums.WordTypeEnum.Noun:
                            AddToRight(node);
                            break;
                        case Enums.WordTypeEnum.Adverb:
                        case Enums.WordTypeEnum.Adjective:
                        case Enums.WordTypeEnum.Preposition:
                            AddToLeft(node);
                            break;
                        case Enums.WordTypeEnum.Conjuction:
                            SetAsParent(node);
                            return Parent;
                            break;
                    }
                    break;
                case Enums.WordTypeEnum.Adverb:
                    switch (node.Value.PartOfSpeechType)
                    {
                        case Enums.WordTypeEnum.Verb:
                        case Enums.WordTypeEnum.Noun:
                        case Enums.WordTypeEnum.Adverb:
                        case Enums.WordTypeEnum.Adjective:
                        case Enums.WordTypeEnum.Preposition:
                            AddToRight(node);
                            break;
                        case Enums.WordTypeEnum.Conjuction:
                            SetAsParent(node);
                            return Parent;
                            break;
                    }
                    break;
                case Enums.WordTypeEnum.Adjective:
                    switch (node.Value.PartOfSpeechType)
                    {
                        case Enums.WordTypeEnum.Verb:
                            AddToLeft(node);
                            break;
                        case Enums.WordTypeEnum.Noun:
                            AddToRight(node);
                            break;
                        case Enums.WordTypeEnum.Adverb:
                            AddToLeft(node);
                            break;
                        case Enums.WordTypeEnum.Adjective:
                            AddToRight(node);
                            break;
                        case Enums.WordTypeEnum.Preposition:
                            AddToRight(node);
                            break;
                        case Enums.WordTypeEnum.Conjuction:
                            SetAsParent(node);
                            break;
                    }
                    break;
                case Enums.WordTypeEnum.Preposition:
                    AddToRight(node);
                    break;
                case Enums.WordTypeEnum.Conjuction:
                    switch (node.Value.PartOfSpeechType)
                    {
                        case Enums.WordTypeEnum.Verb:
                        case Enums.WordTypeEnum.Noun:
                        case Enums.WordTypeEnum.Adverb:
                        case Enums.WordTypeEnum.Adjective:
                        case Enums.WordTypeEnum.Preposition:
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
                        case Enums.WordTypeEnum.Conjuction:
                            SetAsParent(node);
                            return Parent;
                            break;
                    }
                    break;
            }
            return this;
        }

        private void SetAsParent(WordNode node)
        {
            if (this.Parent != null) Parent.AddNode(node);
            else Parent = node;

            Parent.AddNode(this);
        }

        private void AddToLeft(WordNode node)
        {
            if (Left == null)
            {
                node.Parent = this;
                Left = node;
            }
            else Left.AddNode(node);
        }
        private void AddToRight(WordNode node)
        {
            if (Right == null)
            {
                node.Parent = this;
                Right = node;
            }
            else Right.AddNode(node);
        }
    }
}