using NUnit.Framework;
using UnitTests.Books.Services;
using UnitTests.Books.Models;

namespace UnitTests.NUnit;

public class BookServiceTests
{
    private BookService _bookService;
    [SetUp]
    public void SetUp()
    {
        _bookService = new BookService();
    }
    
    [Test]
    [TestCase(TestName = "Get book with NUnit")]
    public async Task Test_GetBook()
    {
        var book = await _bookService.GetBook();
        if (book is null)  throw new Exception("book is null");
    }
    
    [Test]
    [TestCase(TestName = "Create book with NUnit")]
    public async Task Test_CreateBook()
    {
        Book book = new Book("TestCreateBook", "TestCreateBookAuthor", "TestCreateBookTitle", new DateTime());
        var createdBook = await _bookService.CreateBook(book);
        if(createdBook is null)  throw new Exception("created book is null");
        if(createdBook.Title != book.Title) throw new Exception("created book title is invalid");
        if(createdBook.Author != book.Author) throw new Exception("created book author is invalid");
        if(createdBook.Publisher != book.Publisher) throw new Exception("created book publisher is invalid");
    }
    
    [Test]
    [TestCase(TestName = "Update book with NUnit")]
    public async Task Test_UpdateBook()
    {
        var book = await _bookService.GetBook();
        book.Title = "TestUpdateBookTitle";
        book.Author = "TestUpdateBookAuthor";
        book.Publisher = "TestUpdateBookPublisher";
        book.PublishDate = DateTime.Now;
        var updatedBook = await _bookService.UpdateBook(book);
        if (updatedBook is null)  throw new Exception("updated book is null");
        if (updatedBook.Title != "TestUpdateBookTitle") throw new Exception("updated book title is invalid");
        if(updatedBook.Author != "TestUpdateBookAuthor") throw new Exception("updated book author is invalid");
        if(book.Publisher != "TestUpdateBookPublisher") throw new Exception("updated book publisher is invalid");
    }
}