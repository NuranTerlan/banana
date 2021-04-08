using System.Threading.Tasks;
using Application.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    public class BookController : ApiController
    {
        [HttpGet("api/books")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBooksQuery()));
        }
    }
}