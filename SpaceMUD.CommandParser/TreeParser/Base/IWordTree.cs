using SpaceMUD.CommandParser.TreeParser.Node;
using SpaceMUD.CommandParser.TreeParser.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Parser;

namespace SpaceMUD.CommandParser.TreeParser.Base
{
    internal interface IWordTree
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
        /// <returns></returns>
        INode SearchTree(WordTypeEnum typeEnum, int count = 1);

        /// <summary>
        /// Parse tree and return an ordered list of words.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Word> ParseTree();
    }
}
