using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OctaPlayPen.Services;

namespace OctaPlayPen.Controller;
[Route("book")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }    
    [Authorize]
    [HttpGet]
    [Route("get")]
    public IActionResult GetBooks()
    {
        return Ok(_bookService.GetBooks());
    }

    [Authorize]
    [HttpPost]
    [Route("add")]
    public IActionResult AddBooks([FromBody] string book)
    {
        _bookService.AddBooks(book);
        return Ok();
    }
}