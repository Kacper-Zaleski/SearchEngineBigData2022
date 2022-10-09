namespace Indexer.Models
{
    public class TermInDocument
    {
        public int TermId { get; }
        public int DocId { get; }


        /// <summary>
        /// Term occurs count in document
        /// </summary>
        public int Count { get; }

        public TermInDocument(int termId, int docId, int count)
        {
            TermId = termId;
            DocId = docId;
            Count = count;
        }
    }
}