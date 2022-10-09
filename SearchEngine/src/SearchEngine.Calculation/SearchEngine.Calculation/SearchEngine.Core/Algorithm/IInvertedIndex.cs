using Indexer.Models;

namespace MySearchEngine.Core.Analyzer
{
    public interface IInvertedIndex
    {
        void IndexPage(Page token);
        IEnumerable<Page> Search(string query);
        int CountAllIndexes();
    }
}