using DataIndexer.Models;

namespace DataIndexer.Helpers.Calculation
{
    public class Term
    {
        private int _allPageCount { get; set; }

        public double idf
        {
            get => Math.Log10((double)_allPageCount / (double)PageToTermFrequency.Count);
        }

        public Term(int number)
        {
            _allPageCount = number;
            PageToTermFrequency = new Dictionary<Page, int>();
        }

        public Dictionary<Page, int> PageToTermFrequency;

        public double GetTfidf(Page p) => (1 + Math.Log10(PageToTermFrequency[p])) * idf;
    }
}