using AutoMapper;
using Books.Domain.Core.DTOs;
using Books.Domain.Core.Queries.Users;
using Books.Domain.Interfaces.SQL;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.UserInfo
{
    public class UserInfoHandler : IRequestHandler<UserInfoQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserInfoHandler(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UserInfoQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(x => x.Id == Guid.Parse(request.Id), cancellationToken).ConfigureAwait(false);
            return _mapper.Map<UserDto>(user);
        }
    }
}
