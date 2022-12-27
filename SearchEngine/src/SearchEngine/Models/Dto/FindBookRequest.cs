namespace SearchEngine.Models.Dto
{
    public class FindBookRequest
    {
        public string Author { get; set; }
        public string BookId { get; set; }
        public string BookTitle { get; set; }
        public string KeyWords { get; set; }
    }
}