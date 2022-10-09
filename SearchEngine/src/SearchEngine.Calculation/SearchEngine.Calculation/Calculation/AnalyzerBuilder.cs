using Indexer.Analyzer;
using Indexer.Analyzer.TokenFilters;
using Indexer.Analyzer.Tokenizers;
using MySearchEngine.Core.Analyzer;
using SearchEngine.Calculation.SearchEngine.Core.Algorithm;
using SearchEngine.Calculation.SearchEngine.Core.Analyzer.CharacterFilters;

namespace SearchEngine.Calculation.Calculation
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