using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Domain.Core.Identity
{
    [Table("AspNetUsers")]
    public class ApplicationUser: IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surename { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
