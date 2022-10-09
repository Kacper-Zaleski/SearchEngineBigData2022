using Indexer.Models;

namespace Indexer.Analyzer.TokenFilters
{
    public class StopWord
    {
        private readonly List<string> _stopWordList;
        public StopWord(IEnumerable<string> stopWordList)
        {
            _stopWordList = stopWordList.ToList();
        }

        public List<Token> Filter(List<Token> tokens)
        {
            return tokens.Where(x =>
                !_stopWordList.Contains(x.Term)).ToList();
        }
    }
}
