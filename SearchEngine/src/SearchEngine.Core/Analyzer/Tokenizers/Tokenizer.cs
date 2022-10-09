using Indexer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer.Analyzer.Tokenizers
{
    public class Tokenizer: ITokenizer
    {
        private readonly Dictionary<string, Token> _termTokenMapping;
        public Tokenizer()
        {
            _termTokenMapping = new Dictionary<string, Token>();
        }

        public IEnumerable<Token> Tokenize(string text)
        {
            // Tokenize by space
            var index = 0;
            var tokenStart = -1;
            while (index <= text.Length)
            {
                if (index == text.Length || ShouldEscape(text[index]))
                {
                    if (tokenStart >= 0)
                    {
                        var term = text[tokenStart..index];
                        AddToToken(term, tokenStart);
                        tokenStart = -1;
                    }

                }
                else if (index == 0 || (index > 0 && ShouldEscape(text[index - 1])))
                {
                    tokenStart = index;
                }

                index++;
            }

            return _termTokenMapping.Values;
        }

        private void AddToToken(string term, int index)
        {
            var token = _termTokenMapping.ContainsKey(term)
                ? _termTokenMapping[term]
                : new Token(term);

            token.Positions.Add(index);
            _termTokenMapping.TryAdd(term, token);
        }

        private static bool ShouldEscape(char c)
        {
            // Take it simple, tokenize letter and digit only
            return !char.IsLetterOrDigit(c);
        }
    }
}