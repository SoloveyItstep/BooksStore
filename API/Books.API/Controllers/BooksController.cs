using Books.Domain.Core.DbEntities;
using Books.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    public class BooksController : BaseApiController
    {
        public BooksController(DataContext context, IMediator mediator)
           : base(context, mediator)
        { }

        [HttpGet("books")]
        //[ProducesResponseType(typeof(List<Book>), (int)HttpStatusCode.OK)]
        //[Authorize]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _context.Books.ToListAsync().ConfigureAwait(false);
            return Ok(books);
        }
    }
}
