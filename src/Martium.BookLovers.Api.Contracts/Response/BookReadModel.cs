namespace Martium.BookLovers.Api.Contracts.Response
{
    public class BookReadModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string BookName { get; set; }
        public int ReleaseYear { get; set; }
    }
}
