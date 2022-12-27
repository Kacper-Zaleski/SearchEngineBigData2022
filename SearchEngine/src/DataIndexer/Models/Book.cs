namespace DataIndexer.Models
{
    public class Book
    {
        public Book()
        {

        }

        public Book(string author, string name, string pageIndex)
        {
            Id = Guid.NewGuid();
            Author = author;
            Title = name;
            PageIndex = pageIndex;
        }

        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
        public string PageIndex { get; set; }
    }
}