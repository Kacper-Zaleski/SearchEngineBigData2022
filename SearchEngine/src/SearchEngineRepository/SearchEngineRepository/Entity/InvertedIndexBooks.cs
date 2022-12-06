namespace SearchEngineRepository.Entity
{
    public class InvertedIndexBooks
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid InvertedIndexId { get; set; }
    }
}