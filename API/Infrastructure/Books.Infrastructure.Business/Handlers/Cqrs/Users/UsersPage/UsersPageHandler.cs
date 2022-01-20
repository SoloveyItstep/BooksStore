using AutoMapper;
using Books.Domain.Core.DTOs;
using Books.Domain.Core.Queries.Users;
using Books.Domain.Interfaces.SQL;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.UsersPage
{
    public class UsersPageHandler : IRequestHandler<UsersPageQuery, List<UserShortDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersPageHandler(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserShortDto>> Handle(UsersPageQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetPage(request.CurrentPage, request.PageSize, cancellationToken).ConfigureAwait(false);
            return _mapper.Map<List<UserShortDto>>(users);
        }
    }
}
