using DataIndexer.Models;

namespace DataIndexer.Helpers.Calculation
{
    public interface IIndexerProcessor
    {
        Task Index(List<Book> books);
    }
}
