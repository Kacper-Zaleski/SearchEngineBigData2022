
using DataIndexer.Helpers.Algorithm;
using DataIndexer.Helpers.CharacterFilters;
using DataIndexer.Helpers.TokenFilters;
using DataIndexer.Helpers.Tokenizers;
using DataIndexer.Models;

namespace DataIndexer.Helpers
{
    public class Analyzer
    {
        private readonly ITokenizer tokenizer;
        private readonly IIdGenerator<int> idGenerator;
        private readonly IReadOnlyList<ITokenFilter> tokenFilters;
        private readonly IReadOnlyList<ICharacterFilter> characterFilters;

        public Analyzer(
            ITokenizer tokenizer,
            IIdGenerator<int> generator,
            IReadOnlyList<ICharacterFilter> filters,
            IReadOnlyList<ITokenFilter> tokenFilters)
        {
            this.tokenizer = tokenizer;
            this.idGenerator = generator;
            this.characterFilters = filters;
            this.tokenFilters = tokenFilters;
        }

        public List<Token> Analyze(string text, string documentId)
        {
            var filteredText = text;

            var tokens = tokenizer.Tokenize(filteredText, documentId).ToList();

            if (tokenFilters?.Count > 0)
            {
                tokens = tokenFilters.Aggregate(tokens, (current, tokenFilter) => tokenFilter.Filter(current));
            }

            tokens.ForEach(t => t.SetId(idGenerator.Next(t.Term)));

            return tokens;
        }
    }
}