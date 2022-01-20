using Books.Domain.Core.DTOs;
using MediatR;
using System;

namespace Books.Domain.Core.Queries.Users
{
    public class UserInfoQuery: IRequest<UserDto>
    {
        public UserInfoQuery(string id)
        {
            this.Id = id;
        }
        public string Id { get; set; }
        public Guid CurrentUserId { get; set; }
    }
}
