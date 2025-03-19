using UnitTests.Books.Models;
using UnitTests.Books.Services;
using Xunit;

namespace UnitTests.XUnit;

public class BookServiceTests
{
    private readonly BookService _bookService = new();
    
    [Fact(DisplayName = "Get book with xUnit")]
    public async Task Test_GetBook()
    {
        var book = await _bookService.GetBook();
        Assert.NotNull(book);
        Assert.IsType<Book>(book);
    }

    [Fact(DisplayName = "Create book with xUnit")]
    public async Task Test_CreateBook()
    {
        var book = new Book("TestCreate", "TestCreateAuthor", "TestCreatePublisher", new DateTime());
        var createdBook = await  _bookService.CreateBook(book);
        
        Assert.NotNull(createdBook);
        Assert.Equal(book.Title, createdBook.Title);
        Assert.Equal(book.Author, createdBook.Author);
        Assert.Equal(book.Publisher, createdBook.Publisher);
        Assert.True(book.PublishDate.Equals(createdBook.PublishDate));
    }
    
    [Fact(DisplayName = "Update book with xUnit")]
    public async Task Test_UpdateBook()
    {
        var book = new Book("TestUpdate", "TestUpdateAuthor", "TestUpdatePublisher", new DateTime());
        var updatedBook = await  _bookService.UpdateBook(book);
        
        Assert.NotNull(updatedBook);
        Assert.Equal(book.Title, updatedBook.Title);
        Assert.Equal(book.Author, updatedBook.Author);
        Assert.Equal(book.Publisher, updatedBook.Publisher);
        Assert.True(book.PublishDate.Equals(updatedBook.PublishDate));
    }
}