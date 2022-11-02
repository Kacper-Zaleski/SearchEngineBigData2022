using System;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameScraper = new WebScraper();
            nameScraper.GetBooks();
        }
    }
}
