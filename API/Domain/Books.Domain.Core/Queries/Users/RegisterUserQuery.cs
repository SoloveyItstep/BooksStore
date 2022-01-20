using Books.Domain.Core.DTOs;
using MediatR;
using System;

namespace Books.Domain.Core.Queries.Users
{
    public record RegisterUserQuery: IRequest<AccountDto>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Surename { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime? Birthday { get; set; }
    }
}
