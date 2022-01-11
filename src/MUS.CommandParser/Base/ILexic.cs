using MUS.Common.Tools.Attributes.Parser;
using MUS.Entities.Base;
using System;
using System.Collections.Generic;

namespace MUS.CommandParser.Base
{
    public interface ILexic
    {
        /// <summary>
        /// Add PartOfWordAttributes from given Type to Lexic.
        /// </summary>
        /// <param name="type">The given type from which PartOfWordAttributes should be taken from.</param>
        void AddToLexic(Type type);

        /// <summary>
        /// Add PartOfWordAttributes from given List of GameObjects to Lexic.
        /// </summary>
        /// <param name="objects">The given list from which PartOfWordAttributes should be taken from.</param>
        void AddToLexic(IEnumerable<GameObject> objects);

        /// <summary>
        /// Add PartOfWordAttributes from given obj to Lexic.
        /// </summary>
        /// <param name="obj">The given obj from which PartOfWordAttributes should be taken from.</param>
        void AddToLexic(object obj);

        /// <summary>
        /// Add PartOfWordAttributes from given Type to Lexic.
        /// </summary>
        /// <param name="partOfSpeech">The given PartOfWordAttribute that should be added.</param>
        void AddToLexic(PartOfSpeechAttribute partOfSpeech);

        /// <summary>
        /// Finds the specific word in the lexic if there.
        /// </summary>
        /// <param name="word">The word to be searched for in string format.</param>
        /// <returns>The Part Of Speech Attribute linked to the word.</returns>
        PartOfSpeechAttribute FindInLexic(string word);

        /// <summary>
        /// Checks whether the given word is in the lexic.
        /// </summary>
        /// <param name="word">The word to search for.</param>
        /// <returns>True if the word is in lexic.</returns>
        bool IsInLexic(string word);
        bool IsInLexic(PartOfSpeechAttribute attribute);
    }
}
