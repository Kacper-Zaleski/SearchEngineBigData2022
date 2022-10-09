using Indexer.Models;

namespace Indexer.Analyzer
{
    public interface ILanguageBehaviour
    {
        IEnumerable<String> Stem(IEnumerable<String> tokensToStem);
        IEnumerable<String> StopWords { get; }
    }
}