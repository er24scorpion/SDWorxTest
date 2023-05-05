using Application.Commands;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SDWorxTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Books
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Book>))]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _mediator.Send(new GetAllBooksQuery()));
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));

            if (book == null) return NotFound();

            return Ok(book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            return Ok(await _mediator.Send(new UpdateBookCommand(id, book.Title, book.Author)));
        }

        // POST: api/Books
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        public async Task<IActionResult> PostBook(CreateBookCommand book)
        {
            return Ok(await _mediator.Send(book));
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return Ok(await _mediator.Send(new DeleteBookCommand(id)));
        }
    }
}
