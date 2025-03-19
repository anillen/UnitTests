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
        var book = new Book("TestCreateBook", "TestCreateBookAuthor", "TestCreateBookTitle", new DateTime());
        var createdBook = await _bookService.CreateBook(book);
        
        Assert.That(createdBook, Is.Not.Null);
        Assert.That(createdBook.Title, Is.EqualTo(book.Title));
        Assert.That(createdBook.Author, Is.EqualTo(book.Author));
        Assert.That(createdBook.Publisher, Is.EqualTo(book.Publisher));
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
        
        Assert.That(updatedBook, Is.Not.Null);
        Assert.That(updatedBook.Title, Is.EqualTo("TestUpdateBookTitle"));
        Assert.That(updatedBook.Author, Is.EqualTo("TestUpdateBookAuthor"));
        Assert.That(updatedBook.Publisher, Is.EqualTo("TestUpdateBookPublisher"));
    }
}