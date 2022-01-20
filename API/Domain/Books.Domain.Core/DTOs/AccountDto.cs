using System;

namespace Books.Domain.Core.DTOs
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
    }
}
