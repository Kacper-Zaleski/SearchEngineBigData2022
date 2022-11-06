using HtmlAgilityPack;
using MySearchEngine.Core.Models;

namespace SearchEngine.Calculation.SearchEngine.WebCrawler
{
    public class WebScraper
    {
        private const string BaseUrl = "https://www.gutenberg.org/browse/scores/top";
        private const string WebUrl = "https://www.gutenberg.org";

        public IEnumerable<Book> GetBooks()
        {
            var web = new HtmlWeb();
            try
            {
                var document = web.Load(BaseUrl);
                var page = document.DocumentNode;
                var tableRows = page.SelectNodes("//ol/li").Skip(1);
                return GetParsedData(tableRows);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Occured error while fetching: {BaseUrl}, Error: {ex}");
                return null;
            }
        }

        private IEnumerable<Book> GetParsedData(IEnumerable<HtmlNode> webData)
        {
            var parsedBoks = new List<Book>();

            foreach (var tableRow in webData)
            {
                if (tableRow.InnerText != null && tableRow.InnerHtml != null)
                {
                    var parsedBookData = PardeBookData(tableRow.InnerText);
                    var bookHref = GetBookHref(tableRow.InnerHtml);

                    if (parsedBookData != null && bookHref != null)
                    {
                        parsedBookData.Href = WebUrl + bookHref;
                        parsedBoks.Add(parsedBookData);
                    }
                }
            }

            return parsedBoks;
        }

        private Book? PardeBookData(string tableRowData)
        {
            var splitedData = tableRowData.Split(new[] { "by", "(" }, StringSplitOptions.None);
            if (splitedData.Length != 3)
            {
                return null;
            }
            var bookData = new Book(splitedData[0].Trim(), splitedData[1].Trim(), splitedData[2].Trim(')'));

            return bookData;
        }

        public string? GetBookHref(string rowTabe)
        {
            var startIndex = rowTabe.IndexOf('"');
            if (startIndex >= 0)
            {
                var startTrim = rowTabe.Substring(startIndex + 1).Trim();
                var endIndex = startTrim.IndexOf('\"');
                if (endIndex > 0)
                {
                    return startTrim.Substring(0, endIndex).Trim();
                }
            }

            return null;
        }
    }
}