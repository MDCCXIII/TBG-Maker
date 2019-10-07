using System.Collections.Generic;
using TextBasedGameAPI_V2.Enums;

namespace TextBasedGameAPI_V2
{
    internal class SentencePackage
    {
        /// <summary>
        /// the raw sentence with no alteration.
        /// </summary>
        string rawSentence;
        
        //TODO: determine sentence type from sentence structure 
        SentenceType sentenceType { get; set; }

        //TODO: determine and set the structure of the sentence using word replacement rules
        string Structure { get; set; }

        //TODO: populate sentence independent clauses 
        List<IndependentClause> independentClauses = new List<IndependentClause>();

        //TODO: populate sentence dependent clauses
        List<DependantClause> dependantClauses = new List<DependantClause>();

        //TODO: tansform sentence into multiple parts of coordinated information (who, what, when, where, why, and how)
        List<Transformation> Transformations = new List<Transformation>();
    }
}