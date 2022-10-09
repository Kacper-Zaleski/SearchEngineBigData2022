using Indexer.Models;
using MySearchEngine.Core.Analyzer;
using SearchEngine.Calculation.SearchEngine.Core.Algorithm;

namespace SearchEngine.Calculation.Calculation
{
    internal class IndexerProcessor
    {
        private IIdGenerator<int> termIdGenerator;
        private IEnumerable<Page> allPages;
        private IInvertedIndex? index = null;

        public IndexerProcessor()
        {
            allPages = GetAllPages();
            termIdGenerator = new GlobalTermIdGenerator();

            //tokenize and index all pages
            var analyzer = AnalyzerBuilder.BuildTextAnalyzer(termIdGenerator);
            index = new InvertedIndex(allPages.Count());

            Parallel.ForEach(allPages, p =>
            {
                var textAnalyzer = AnalyzerBuilder.BuildTextAnalyzer(termIdGenerator);
                var tokens = textAnalyzer.Analyze(p.SiteText);
                if (tokens != null)
                {
                    p.Tokens = tokens;
                    index.IndexPage(p);
                }
            });

            index.InitialiseIndex();
        }

        public IInvertedIndex CreateIndex()
        {
            return index;
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
