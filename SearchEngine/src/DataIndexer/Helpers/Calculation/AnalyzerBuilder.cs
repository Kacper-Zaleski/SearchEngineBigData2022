using DataIndexer.Helpers.Algorithm;
using DataIndexer.Helpers.CharacterFilters;
using DataIndexer.Helpers.TokenFilters;
using DataIndexer.Helpers.Tokenizers;

namespace DataIndexer.Helpers.Calculation
{
    public class AnalyzerBuilder
    {
        public static Analyzer BuildTextAnalyzer(IIdGenerator<int> idGenerator)
        {
            return new Analyzer(
                new Tokenizer(),
                idGenerator,
                new List<ICharacterFilter> { new CharacterFilter() },
                new List<ITokenFilter>
                {
                    new LowerCase(),
                    new StopWord()
                });
        }
    }
}