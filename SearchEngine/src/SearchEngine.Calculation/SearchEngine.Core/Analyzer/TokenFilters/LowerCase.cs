using Indexer.Models;

namespace Indexer.Analyzer.TokenFilters
{
    internal class LowerCase: ITokenFilter
    {
        public List<Token> Filter(List<Token> tokens)
        {
            tokens.ForEach(t => t.Term = t.Term.ToLower());
            return tokens;
        }
    }
}