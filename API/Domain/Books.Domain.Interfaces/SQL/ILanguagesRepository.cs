using Books.Domain.Core.DbEntities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces.SQL
{
    public interface ILanguagesRepository: IRepository<Languages>
    {
        Task<List<string>> LanguageCodes(CancellationToken cancellationToken = default);
    }
}
