using Indexer.Models;
using MySearchEngine.Core.Models;
using SearchEngine.Calculation.Calculation;
using SearchEngine.Calculation.SearchEngine.Core.Algorithm;
using System.Collections.Concurrent;

namespace MySearchEngine.Core.Analyzer
{
    public class InvertedIndex : IInvertedIndex
    {
        // Maps a term to relevant values being tf, idf, and tf-idf.
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
            foreach (var token in page.Tokens)
            {
                Console.WriteLine($"ID: {token.Id} | Term: {token.Term} | Positions: [{string.Join(", ", token.Positions)}] | TermsInDoc: {token.TermsInDoc}");
            }
        }

        // Initialised the index by precomputing the lengths of each vector in the index
        public void InitialiseIndex()
        {
            Dictionary<Page, double> lengthVector = new Dictionary<Page, double>();

            foreach (var (term, indexValue) in index)
            {
                foreach (var (page, _) in indexValue.PageToTermFrequency)
                {
                    if (!lengthVector.ContainsKey(page))
                        lengthVector.Add(page, 0);

                    lengthVector[page] += indexValue.GetTfidf(page);
                }
            }

            foreach (var (page, length) in lengthVector)
                vectorLengths[page] = Math.Sqrt(length);
        }

        // Implements Cosine similarity to do content-based searching.
        public IEnumerable<Page> Search(String query)
        {
            Dictionary<Page, double> Scores = new Dictionary<Page, double>();

            foreach (String term in query.Split(" "))
            {
                if (!index.ContainsKey(term))
                    continue;

                var indexValue = index[term];

                // Iterate over all pages, that contain the term
                foreach (Page page in indexValue.PageToTermFrequency.Keys)
                {
                    if (!Scores.ContainsKey(page))
                        Scores.Add(page, 0);

                    Scores[page] += indexValue.GetTfidf(page);
                }
            }

            foreach (Page p in Scores.Keys.ToList())
                Scores[p] /= vectorLengths[p];

            return Scores.OrderByDescending(x => x.Value).Select(x => x.Key).Take(10);
        }

        public void Index(Page token)
        {
            throw new NotImplementedException();
        }

        public int CountAllIndexes()
        {
            return index.Count();
        }
    }
}