using Books.Domain.Core.DTOs;
using MediatR;
using System;

namespace Books.Domain.Core.Queries.Users
{
    public class UpdateUserQuery: IRequest<AccountDto>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surename { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
