using System;

namespace Books.Domain.Core.Account
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
