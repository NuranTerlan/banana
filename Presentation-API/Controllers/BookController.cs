using System.Threading.Tasks;
using Application.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    public class BookController : Controller
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/books")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllBooksQuery()));
        }
    }
}