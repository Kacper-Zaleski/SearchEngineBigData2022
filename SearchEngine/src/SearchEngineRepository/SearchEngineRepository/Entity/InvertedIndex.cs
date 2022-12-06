namespace SearchEngineRepository.Entity
{
    public class InvertedIndex
    {
        public Guid Id { get; set; }
        public string Word { get; set; }
        public IndexOnType IndexOnType { get; set; }
        public List<InvertedIndexBooks> Indexes { get; set; }
    }
}