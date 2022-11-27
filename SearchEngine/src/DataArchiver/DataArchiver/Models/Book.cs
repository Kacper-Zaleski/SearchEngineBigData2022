namespace DataArchiver.Models
{
    public class Book
    {
        public Book()
        {

        }

        public Book(string[] authors, string name, string pageIndex)
        {
            Id = Guid.NewGuid();
            Authors = authors;
            Title = name;
            PageIndex = pageIndex;
        }

        public Guid Id { get; set; }
        public string[] Authors { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Invocation { get; set; }
        public DateTime RealeseDate { get; set; }
        public string Href { get; set; }
        public string PageIndex { get; set; }
    }
}