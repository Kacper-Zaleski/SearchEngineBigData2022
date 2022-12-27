namespace SearchEngine.Models.Dto
{
    public class FindBookResponse
    {
        public IEnumerable<BookDto> Books { get; set; }
    }
}