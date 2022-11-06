using SearchEngine.Calculation.Calculation;
using SearchEngine.Calculation.SearchEngine.WebCrawler;
using System.Diagnostics;

class Program
{
    private static async Task Main(string[] args)
    {
        var stopwatch = Stopwatch.StartNew();
        var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(5));
        var index = new IndexerProcessor();
        var webScraper = new WebScraper();
        var archiver = new DataArchiver(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName));

        while (await periodicTimer.WaitForNextTickAsync())
        {
            try
            {
                var books = webScraper.GetBooks();

                archiver.ArchiveData(books.ToList());

                index.Index(books);

                Console.WriteLine(books.Count());
                Console.WriteLine($"Periodic Time: {stopwatch.ElapsedMilliseconds / 1000}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}