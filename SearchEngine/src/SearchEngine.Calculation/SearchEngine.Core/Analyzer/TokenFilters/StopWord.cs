using Indexer.Models;

namespace Indexer.Analyzer.TokenFilters
{
    public class StopWord: ITokenFilter
    {
        private readonly List<string> stopWordList;
        public StopWord()
        {
            this.stopWordList = GenerateStopWords().ToList();
        }

        public List<Token> Filter(List<Token> tokens)
        {
            return tokens.Where(x =>
                !this.stopWordList.Contains(x.Term)).ToList();
        }

        private static IEnumerable<string> GenerateStopWords()
        {
            var lines = File.ReadLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\SearchEngine.Core\\Analyzer\\TokenFilters\\StopWords\\EnglishStopWords.txt"));

            foreach (var line in lines)
            {
                yield return line;
            }
        }
    }
}