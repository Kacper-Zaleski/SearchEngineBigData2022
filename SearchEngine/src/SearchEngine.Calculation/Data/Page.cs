using Indexer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SearchEngine.Calculation.Data
{
    public class Page
    {
        public string Id { get; set; }
        public Uri Url { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string SiteId { get; set; }
        public string SiteText { get; set; }
        public double PageRank { get; set; }
        public IEnumerable<Token> Tokens { get; set; }
        public Page()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Page))
            {
                return false;
            }
            Page other = (Page)obj;
            return other.Url == Url;
        }

        public override int GetHashCode()
        {
            return Url.GetHashCode();
        }
    }
}