using Books.Domain.Core.Queries.Users;
using Books.Domain.Interfaces.SQL;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<bool> Handle(DeleteUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(x => x.Email == request.Email, cancellationToken).ConfigureAwait(false);
            await _userRepository.Delete(user, cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
