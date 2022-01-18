using Books.Domain.Core.Account;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces.SQL
{
    public interface IUserRepository: IRepository<ApplicationUser>
    {
        Task<ApplicationUser> Get(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default);
    }
}
