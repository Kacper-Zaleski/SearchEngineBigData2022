using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebCrawler
{
    public class WebScraper
    {
        private const string BaseUrl = "https://www.gutenberg.org/browse/scores/top";

        public void GetBooks()
        {
            var web = new HtmlWeb();
            var document = web.Load(BaseUrl);

            var tableRows = document.QuerySelectorAll("ol li").Skip(1);

            foreach (var tableRow in tableRows)
            {
                var tds = tableRow.QuerySelectorAll("li");

                var name = tds[0].InnerText;
                var href = tds[0].QuerySelector("a").Attributes["href"].Value;

                Console.WriteLine($"Name: {name}, Link: {href}");
            }
        }
    }
}

