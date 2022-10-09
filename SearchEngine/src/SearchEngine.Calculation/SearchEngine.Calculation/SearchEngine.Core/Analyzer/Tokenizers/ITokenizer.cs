using Indexer.Models;

namespace MySearchEngine.Core.Analyzer
{
    public interface ITokenizer
    {
        IEnumerable<Token> Tokenize(string text);
    }
}