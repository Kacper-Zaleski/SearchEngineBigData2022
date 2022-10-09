using Indexer.Models;
using MySearchEngine.Core.Models;
using SearchEngine.Calculation.Calculation;
using SearchEngine.Calculation.SearchEngine.Core.Algorithm;
using System.Collections.Concurrent;

namespace MySearchEngine.Core.Analyzer
{
    public class InvertedIndex : IInvertedIndex
    {
        private ConcurrentDictionary<string, Term> index { get; set; }

        private Dictionary<Page, double> vectorLengths;
        int allPagesCount;

        public InvertedIndex(int allPagesCount)
        {
            this.index = new ConcurrentDictionary<string, Term>();
            this.vectorLengths = new Dictionary<Page, double>();
            this.allPagesCount = allPagesCount;
        }

        public void IndexPage(Page page)
        {
            allPagesCount++;
            foreach (var token in page.Tokens)
            {
                Console.WriteLine($"ID: {token.Id} | Term: {token.Term} | Positions: [{string.Join(", ", token.Positions)}] | Positions Id: [{string.Join(", ", token.PositionInDocuments)}] | Terms in -> documents count: {token.TermsInDoc}");
            }
        }

        public void Index(Page token)
        {
            throw new NotImplementedException();
        }

        public int CountAllIndexes()
        {
            return allPagesCount;
        }

        public IEnumerable<Page> Search(string query)
        {
            throw new NotImplementedException();
        }
    }
}