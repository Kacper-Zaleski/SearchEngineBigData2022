using MySearchEngine.Core.Models;

namespace SearchEngine.Calculation.Calculation
{
    public interface IIndexer
    {
        void Index(DocumentInformation documentInformation, string content);
        int GetTotalDocCount();
        bool TryGetIndexedDocs(string term, out List<TermInDocument> pages);
        bool TryGetDocInfo(int pageId, out DocumentInformation documentInformation);

        Task StoreDataAsync();
    }
}
