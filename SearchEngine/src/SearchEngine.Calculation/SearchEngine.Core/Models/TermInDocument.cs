namespace MySearchEngine.Core.Models
{
    public class TermInDocument
    {
        public int TermId { get; }
        public int DocId { get; }
        public int Count { get; }

        public TermInDocument(int termId, int docId, int count)
        {
            TermId = termId;
            DocId = docId;
            Count = count;
        }
    }
}