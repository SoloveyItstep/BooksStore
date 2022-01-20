using Books.Domain.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces.SQL
{
    public interface IUserRepository: IRepository<ApplicationUser>
    {
        Task<ApplicationUser> Get(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default);
        Task<List<ApplicationUser>> GetPage(int current, int pageSize, CancellationToken cancellationToken = default);
    }
}
