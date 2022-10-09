using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer.Models
{
    public class Token
    {
        public int Id { get; private set; }
        public string Term { get; set; }
        public List<int> Positions { get; set; }

        public int TermsInDoc => Positions.Count;

        public Token(string term)
        {
            Term = term;
            Positions = new List<int>();
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}