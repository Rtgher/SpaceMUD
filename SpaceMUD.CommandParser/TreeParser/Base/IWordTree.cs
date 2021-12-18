using SpaceMUD.CommandParser.TreeParser.Node;
using SpaceMUD.CommandParser.TreeParser.Words;
using System.Collections.Generic;
using SpaceMUD.Common.Enums.Parser;

namespace SpaceMUD.CommandParser.TreeParser.Base
{
    public interface IWordTree : IEnumerable<INode>
    { 
        INode RootNode { get; }
        void AddValue(Word word);
        /// <summary>
        /// Search for a specific word and returns the node it belongs to.
        /// </summary>
        /// <param name="word">The word to search for</param>
        /// <returns>The node the word belongs to.</returns>
        INode SearchTree(Word word);
        /// <summary>
        /// Search for first (count) occurence of the specified wordtype.
        /// </summary>
        /// <param name="typeEnum">The type enum to search by.</param>
        /// <param name="count">Number of occurence of that typeEnu to get.</param>
        INode SearchTree(WordTypeEnum typeEnum, int count = 1);

        /// <summary>
        /// Parse tree and return an ordered list of words.
        /// </summary>
        IEnumerable<INode> ParseTree();

        /// <summary>
        /// Retrieve all the given parts nodes in the tree.
        /// Use to get all Verb nodes, all Attribute nodes, all conjunction nodes etc...
        /// </summary>
        /// <param name="wordType">The Word type of which node to be retrieved.</param>
        /// <returns></returns>
        IEnumerable<INode> GetParts(WordTypeEnum wordType);

        int Count();
    }
}
