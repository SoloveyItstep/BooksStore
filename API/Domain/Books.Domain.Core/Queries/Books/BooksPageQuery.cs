using Books.Domain.Core.DbEntities.Books;
using MediatR;
using System.Collections.Generic;

namespace Books.Domain.Core.Books.Queries
{
    public class BooksPageQuery: IRequest<List<Book>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string Language { get; set; }
    }
}
