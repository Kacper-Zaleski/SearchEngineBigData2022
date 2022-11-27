namespace SearchEngineRepository.Entity
{
    public class InvertedIndex
    {
        public Guid Id { get; set; }
        public List<BookIndex> Indexes { get; set; }
    }
}
