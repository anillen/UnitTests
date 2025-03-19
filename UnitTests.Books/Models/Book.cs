namespace UnitTests.Books.Models;

public class Book(string title, string author, string publisher, DateTime publishDate)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
    public string Publisher { get; set; } = publisher;
    public DateTime PublishDate { get; set; } = publishDate;
}