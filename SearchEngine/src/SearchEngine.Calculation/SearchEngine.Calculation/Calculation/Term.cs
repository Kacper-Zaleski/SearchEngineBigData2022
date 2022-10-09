﻿using Indexer.Models;

namespace SearchEngine.Calculation.Calculation
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

        // Contains all pages that contain the term, and the termfrequency for
        // that term in that page.
        public Dictionary<Page, int> PageToTermFrequency;

        public double GetTfidf(Page p) => (1 + Math.Log10(PageToTermFrequency[p])) * idf;
    }
}