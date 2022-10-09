using Indexer.Models;
using MySearchEngine.Core.Analyzer;

namespace Indexer.Analyzer.Tokenizers
{
    public class Tokenizer: ITokenizer
    {
        private readonly Dictionary<string, Token> termTokenMapping;
        public Tokenizer()
        {
            this.termTokenMapping = new Dictionary<string, Token>();
        }

        public IEnumerable<Token> Tokenize(string text)
        {
            // Tokenize by space
            var index = 0;
            var tokenStart = -1;
            while (index <= text.Length)
            {
                if (index == text.Length || IsLetterOrNumber(text[index]))
                {
                    if (tokenStart >= 0)
                    {
                        var term = text[tokenStart..index];
                        AddToToken(term, tokenStart);
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

        private void AddToToken(string term, int index)
        {
            var token = termTokenMapping.ContainsKey(term)
                ? termTokenMapping[term]
                : new Token(term);

            token.Positions.Add(index);
            termTokenMapping.TryAdd(term, token);
        }

        private static bool IsLetterOrNumber(char c)
        {
            //Tokenize letter and digit only
            return !char.IsLetterOrDigit(c);
        }
    }
}