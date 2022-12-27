using DataIndexer.Models;

namespace DataIndexer.Helpers.Algorithm
{
    public interface IInvertedIndex
    {
        void IndexPage(Page token);
        IEnumerable<Page> Search(string query);
        int CountAllIndexes();
    }
}