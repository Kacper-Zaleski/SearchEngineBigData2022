using System.ComponentModel.DataAnnotations;

namespace SearchEngineRepository.Entity
{
    public class InvertedIndexBooks
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]

        public Guid BookId { get; set; }

        [Required]
        public Guid InvertedIndexId { get; set; }

    }
}