using System.Collections.Concurrent;

namespace DataIndexer.Helpers.Algorithm
{
    public class GlobalTermIdGenerator : IIdGenerator<int>
    {
        private readonly IntegerIdGenerator idGenerator;
        private readonly ConcurrentDictionary<string, int> termIdDict;
        public GlobalTermIdGenerator()
        {
            this.idGenerator = new IntegerIdGenerator();
            this.termIdDict = new ConcurrentDictionary<string, int>();
        }

        public int Next(string parameter)
        {
            // parameter is 'term'
            if (termIdDict.TryGetValue(parameter, out int termId))
            {
                return termId;
            }

            // Not thread safe
            termId = idGenerator.Next(null);
            termIdDict.TryAdd(parameter, termId);
            return termId;
        }
    }
}