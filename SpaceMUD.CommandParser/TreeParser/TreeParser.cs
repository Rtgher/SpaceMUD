using SpaceMUD.CommandParser.Base;
using SpaceMUD.CommandParser.Dictionary;
using SpaceMUD.CommandParser.TreeParser.Base;
using SpaceMUD.CommandParser.TreeParser.Words;
using SpaceMUD.Common.Tools.Attributes.Parser;

namespace SpaceMUD.CommandParser.TreeParser
{
    public class TreeParser : ICommandParser
    {
        public WordDictionary Lexic { get; }

        public TreeParser(WordDictionary lexic)
        {
            Lexic = lexic;
        }

        public IWordTree ParseCommand(string command)
        {
            var tree =  ParseTree(command);

        }

        private IWordTree ParseTree(string command)
        {
            IWordTree tree;
            var words = command.Split();
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (i + 1 < words.Length)
                {
                    var doubleword = word + ' ' + words[i + 1];
                    if (Lexic.IsInLexic(doubleword))
                    {
                        var pos = Lexic.FindInLexic(doubleword);
                        var w = new Word(doubleword, pos);
                        tree.AddValue(w);
                        i++;
                        continue;
                    }
                }

                var partOfSpeech = Lexic.FindInLexic(word);
                if (partOfSpeech != null)
                {
                    tree.AddValue(new Word(word, partOfSpeech));
                }
                else
                {
                    var w = new Word(word, new AdjectiveAttribute(word));
                }

            }

            return tree;
        }
    }
}
