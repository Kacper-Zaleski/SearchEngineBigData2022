using DataIndexer.Models;

namespace DataIndexer.Helpers.Tokenizers
{
    public interface ITokenizer
    {
        IEnumerable<Token> Tokenize(string text, string documentId);
    }
}