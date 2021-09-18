using Books.Domain.Core.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Books.Domain.Core.Queries
{
    public record RegisterUserQuery: IRequest<UserDto>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(9), MaxLength(14)]
        public string Phone { get; set; }
    }
}
