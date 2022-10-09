using Indexer.Models;

namespace Indexer.Analyzer
{
    public interface ITokenizer
    {
        IEnumerable<Token> Tokenize(string text);
    }
}