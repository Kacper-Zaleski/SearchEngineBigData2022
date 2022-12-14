using DataIndexer.Helpers.Calculation;
using DataIndexer.Models;
using System.Collections.Concurrent;

namespace DataIndexer.Helpers.Algorithm
{
    public class InvertedIndex : IInvertedIndex
    {
        private ConcurrentDictionary<string, Term> index { get; set; }

        private Dictionary<Page, double> vectorLengths;
        private int allPagesCount = 0;

        public InvertedIndex()
        {
            this.index = new ConcurrentDictionary<string, Term>();
            this.vectorLengths = new Dictionary<Page, double>();
        }

        public void IndexPage(Page page)
        {
            allPagesCount++;

            foreach (var token in page.Tokens)
            {
                Console.WriteLine($"ID: {token.Id} | Term: {token.Term} | Positions: [{string.Join(", ", token.Positions)}] | Positions Id: [{string.Join(", ", token.PositionInDocuments)}] | Terms in -> documents count: {token.TermsInDoc}");
            }
        }

        public int CountAllIndexes()
        {
            return allPagesCount;
        }

        public IEnumerable<Page> Search(string query)
        {
            throw new NotImplementedException();
        }

        //public string ToString()
        //{
        //    return ;
        //}
    }
}