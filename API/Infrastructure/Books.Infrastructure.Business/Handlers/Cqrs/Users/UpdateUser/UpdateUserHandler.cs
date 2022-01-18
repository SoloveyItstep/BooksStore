using Books.Domain.Core.DTOs;
using Books.Domain.Core.Queries.Users;
using Books.Domain.Interfaces.SQL;
using Books.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserQuery, UserDto>
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public UpdateUserHandler(IUserRepository repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Handle(UpdateUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.Get(x => x.Email == request.Email, cancellationToken).ConfigureAwait(false);
            
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Birthday = request.Birthday;
            user.Phone = request.Phone;
            user.Surename = request.Surename;

            await _repository.Update(user).ConfigureAwait(false);
            return new UserDto
            {
                FirstName = request.FirstName,
                Token = _tokenService.CreateToken(user.Email),
                Email = request.Email
            };
        }
    }
}
