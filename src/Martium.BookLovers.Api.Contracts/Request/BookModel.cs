namespace Martium.BookLovers.Api.Contracts.Request
{
    public class BookModel
    {
        public int AuthorId { get; set; }
        public string BookName { get; set; }
        public int ReleaseYear { get; set; }
    }
}
