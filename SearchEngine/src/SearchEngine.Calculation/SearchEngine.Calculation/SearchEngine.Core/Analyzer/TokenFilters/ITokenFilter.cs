using Indexer.Models;

namespace Indexer.Analyzer
{
    public interface ITokenFilter
    {
        List<Token> Filter(List<Token> tokens);
    }
}