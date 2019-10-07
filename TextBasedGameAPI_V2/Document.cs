using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedGameAPI_V2.Enums;

namespace TextBasedGameAPI_V2
{
    class Document
    {
        /// <summary>
        /// the raw text of a document with no alterations
        /// </summary>
        string[] raw;

        //TODO: parse raw data for sentences -- MOVED TO sentencePackages
        /// <summary>
        /// an array of sentences obstracted from the raw data using punctuations as delimiters
        /// </summary>
        string[] sentences;

        //TODO: determine sentence type -- MOVED TO sentencePackages
        /// <summary>
        /// associative dictionary of sentence types the int key of this dictionary is the index of the sentence in the sentences array
        /// </summary>
        Dictionary<int, SentenceType> sentenceType = new Dictionary<int, SentenceType>();

        //TODO: determineSentencePackage
        /// <summary>
        /// the key of this dictionary is the index of the sentence in the sentences array
        /// </summary>
        Dictionary<int, SentencePackage> sentencePackages = new Dictionary<int, SentencePackage>();
    }
}
