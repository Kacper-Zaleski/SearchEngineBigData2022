using DataIndexer.Models;

namespace DataIndexer.Helpers.Tokenizers
{
    public class Tokenizer: ITokenizer
    {
        private readonly Dictionary<string, Token> termTokenMapping;
        public Tokenizer()
        {
            this.termTokenMapping = new Dictionary<string, Token>();
        }

        public IEnumerable<Token> Tokenize(string text, string documentId)
        {
            var index = 0;
            var tokenStart = -1;
            while (index <= text.Length)
            {
                if (index == text.Length || IsLetterOrNumber(text[index]))
                {
                    if (tokenStart >= 0)
                    {
                        var term = text[tokenStart..index];
                        AddToToken(term, tokenStart, documentId);
                        tokenStart = -1;
                    }

                }
                else if (index == 0 || (index > 0 && IsLetterOrNumber(text[index - 1])))
                {
                    tokenStart = index;
                }

                index++;
            }

            return termTokenMapping.Values;
        }

        private void AddToToken(string term, int index, string documentId)
        {
            var token = termTokenMapping.ContainsKey(term)
                ? termTokenMapping[term]
                : new Token(term);

            token.Positions.Add(index);
            token.PositionInDocuments.Add(documentId);
            termTokenMapping.TryAdd(term, token);
        }

        private static bool IsLetterOrNumber(char c)
        {
            return !char.IsLetterOrDigit(c);
        }
    }
}