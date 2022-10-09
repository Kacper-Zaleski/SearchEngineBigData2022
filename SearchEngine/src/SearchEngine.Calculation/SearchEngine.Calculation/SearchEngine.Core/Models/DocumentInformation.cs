namespace MySearchEngine.Core.Models
{
    public class DocumentInformation
    {
        public int DocId { get; private set; }
        public string Title { get; }
        public string Url { get; }
        public int TokenCount { get; private set; }

        public DocumentInformation(int docId, string title, string url)
        {
            DocId = docId;
            Title = title;
            Url = url;
        }

        public DocumentInformation(int docId, string title, string url, int tokenCount)
            : this(docId, title, url)
        {
            TokenCount = tokenCount;
        }

        public void SetTokenCount(int count)
        {
            TokenCount = count;
        }

        public void SetId(int id)
        {
            DocId = id;
        }
    }
}