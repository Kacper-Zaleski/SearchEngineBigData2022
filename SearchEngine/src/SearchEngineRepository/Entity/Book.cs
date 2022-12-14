using System.ComponentModel.DataAnnotations;

namespace SearchEngineRepository.Entity
{
    public class Book
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Authors { get; set; }
        public string Title { get;set; }
        public string Language { get; set; }
        public string Invocation { get; set; }
        public DateTime RealeseDate { get; set; }
        public string Href { get; set; }
        public string PageIndex { get; set; }
    }
}