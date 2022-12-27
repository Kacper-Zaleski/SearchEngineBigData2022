using System.ComponentModel.DataAnnotations;

namespace SearchEngineRepository.Entity
{
    public class InvertedIndex
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Word { get; set; }
        public IndexOnType IndexOnType { get; set; }
        public List<InvertedIndexBooks> Books { get; set; }
    }
}