using Indexer.Models;
using MySearchEngine.Core.Analyzer;
using MySearchEngine.Core.Models;
using SearchEngine.Calculation.Data;
using SearchEngine.Calculation.SearchEngine.Core.Algorithm;

namespace SearchEngine.Calculation.Calculation
{
    internal class IndexerProcessor
    {
        private IIdGenerator<int> termIdGenerator;
        private IInvertedIndex? index = null;
        private Analyzer analyzer;

        public IndexerProcessor()
        {
            termIdGenerator = new GlobalTermIdGenerator();
            analyzer = AnalyzerBuilder.BuildTextAnalyzer(termIdGenerator);
            index = new InvertedIndex();
        }

        public void Index(IEnumerable<Book> books)
        {
            Parallel.ForEach(books, book =>
            {
                var page = new Page();

                var textAnalyzer = AnalyzerBuilder.BuildTextAnalyzer(termIdGenerator);
                var tokens = textAnalyzer.Analyze($"{book.Title} {book.Author} {book.PageIndex}", book.Id.ToString());
                if (tokens != null)
                {
                    page.Title = book.Title;
                    page.Author = book.Author;
                    page.Url = new Uri(book.Href);
                    page.SiteId = book.PageIndex;
                    page.Title = book.Title;
                    page.Tokens = tokens;

                    index.IndexPage(page);
                }
            });
        }

        private IEnumerable<Page> GetAllPages()
        {
            List<Page> pages = new List<Page>();
            string text = File.ReadAllText( Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Data\\data.txt"));
            string[] strippedText = text.Split("\r\n\r\n");
            foreach (string p in strippedText)
            {
                Page page = new Page();
                var lines = p.Split("\r\n");
                foreach (var line in lines)
                {
                    var temp = line.Split(": ");
                    if (temp.Length >= 2 && temp[0].Contains("id"))
                        page.Id = temp[1];
                    if (temp[0].Contains("url"))
                        page.Url = new Uri(temp[1]);
                    if (temp[0].Contains("sitetext"))
                        page.SiteText = temp[1];
                    if (temp[0].Contains("title") && temp.Length >= 2)
                        page.Title = temp[1];
                }
                if (page.Url != null)
                    pages.Add(page);
            }

            return pages;
        }
    }
}