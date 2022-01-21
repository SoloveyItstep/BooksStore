using Books.Domain.Core.Books.Queries;
using Books.Domain.Core.DbEntities.Books;
using Books.Domain.Interfaces.SQL;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Books.BooksPage
{
    public class BooksPageHandler : IRequestHandler<BooksPageQuery, List<Book>>
    {
        private readonly IBooksRepository _repository;

        public BooksPageHandler(IBooksRepository repository)
        {
            this._repository = repository;
        }

        public async Task<List<Book>> Handle(BooksPageQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPage(request.CurrentPage, request.PageSize, cancellationToken).ConfigureAwait(false);
        }
    }
}
