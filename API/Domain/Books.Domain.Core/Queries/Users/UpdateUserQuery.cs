using Books.Domain.Core.DTOs;
using MediatR;
using System;

namespace Books.Domain.Core.Queries.Users
{
    public class UpdateUserQuery: IRequest<UserDto>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surename { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
