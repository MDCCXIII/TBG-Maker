namespace TextBasedGameAPI_V2.Enums
{
    internal enum SentenceType
    {
        /// <summary>
        /// A simple sentence contains only one independent clause. <para />
        /// An independent clause is a group of words that has both a subject and a verb, and expresses a complete thought.
        /// </summary>
        SIMPLE,

        /// <summary>
        /// A compound sentence contains at least two independent clauses. These clauses are joined by a coordinating conjunction or a semicolon. <para />
        /// (When you join two independent clauses with only a comma, it's a mistake called a comma splice) <para />
        /// A coordinating conjunction is a word that glues words, phrases, or clauses together. <para />
        /// </summary>
        COMPOUND,

        /// <summary>
        /// A complex sentence contains a subordinate clause and an independent clause.<para />
        /// A subordinate clause is a group of words that has a subject and a verb but does not express a complete thought.
        /// </summary>
        COMPLEX,

        /// <summary>
        /// These are basically a combination of compound sentences and complex sentences. <para /> 
        /// They contain at least two independent clauses and at least one subordinate clause.
        /// </summary>
        COMPOUNDCOMPLEX
    }
}