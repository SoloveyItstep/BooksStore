using Books.Domain.Core.DTOs;
using Books.Domain.Core.Queries.Users;
using Books.Domain.Interfaces.SQL;
using Books.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserQuery, AccountDto>
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public UpdateUserHandler(IUserRepository repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public async Task<AccountDto> Handle(UpdateUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.Get(x => x.Id == request.Id, cancellationToken).ConfigureAwait(false);
            
            user.FirstName = request.FirstName.Trim();
            user.LastName = request.LastName.Trim();
            user.Birthday = request.Birthday;
            user.PhoneNumber = request.Phone.Trim();
            user.Surename = request.Surename?.Trim();

            await _repository.Update(user, cancellationToken).ConfigureAwait(false);
            return new AccountDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Token = await _tokenService.CreateToken(user),
                Email = user.Email
            };
        }
    }
}
