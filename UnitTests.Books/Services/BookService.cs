using UnitTests.Books.Models;

namespace UnitTests.Books.Services;

public class BookService
{
    public async Task<Book> GetBook()
    {
        await Task.Delay(1000);
        return new Book("Test","TestAuthor", "TestPublisher", new DateTime());
    }
    public async Task<Book> CreateBook(Book book)
    {
        await Task.Delay(1000);
        return book;
    }
    public async Task<Book> UpdateBook(Book book)
    {
        await Task.Delay(1000);
        return book;
    }
}