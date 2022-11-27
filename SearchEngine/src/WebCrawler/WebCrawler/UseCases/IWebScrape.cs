using WebCrawler.Models;

namespace WebCrawler.UseCases
{
    public interface IWebScrape
    {
        public Task<IEnumerable<Book>> GetBooks();
    }
}
