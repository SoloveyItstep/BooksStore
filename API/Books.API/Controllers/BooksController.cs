using Books.Domain.Core.DbEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Books.Domain.Core.Books.Queries;
using Microsoft.AspNetCore.Authorization;
using Books.Domain.Core.Constants;

namespace Books.API.Controllers
{
    public class BooksController : BaseApiController
    {
        //MongoContext mongoContext;
        //IDistributedCache cache;
        //IBooksRepository repository;

        public BooksController(IMediator mediator)
           : base(mediator)
        { }

        //[HttpGet("books")]
        //[ProducesResponseType(typeof(List<Book>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<List<Book>>> GetBooks()
        //{
        //    //await this.mongoContext.Test();
        //    //var cacheKey = "allBooks";
        //    //var books = await cache.GetRecordAsync<IEnumerable<Book>>(cacheKey).ConfigureAwait(false);
        //    //if (books is null)
        //    //{
        //        var books = await repository.GetAll().ConfigureAwait(false);
        //    //    await cache.SetRecordAsync(cacheKey, books).ConfigureAwait(false);
        //    //}
        //    return Ok(books);
        //}

        [HttpPost("page")]
        //[Authorize(Roles = RolesList.Admin)]
        [ProducesResponseType(typeof(List<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Book>>> GetPage(BooksPageQuery query)
        {
            var result = await this._mediator.Send(query);
            return Ok(result);
        }
    }
}
