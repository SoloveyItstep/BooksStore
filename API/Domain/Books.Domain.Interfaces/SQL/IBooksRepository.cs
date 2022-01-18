using Books.Domain.Core.DbEntities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces.SQL
{
    public interface IBooksRepository: IRepository<Book>
    {
        Task<List<Book>> GetPage(int pageNumber, int pageLength, CancellationToken cancellationToken = default);
        Task<List<Book>> GetPage(int pageNumber, int pageLength, string language, CancellationToken cancellationToken = default);
    }
}
