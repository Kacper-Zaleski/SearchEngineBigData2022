using DataIndexer.Models;

namespace DataIndexer.Helpers.TokenFilters
{
    public interface ITokenFilter
    {
        List<Token> Filter(List<Token> tokens);
    }
}