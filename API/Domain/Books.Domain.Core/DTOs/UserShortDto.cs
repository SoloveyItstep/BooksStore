using System;

namespace Books.Domain.Core.DTOs
{
    public class UserShortDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surename { get; set; }
        public string PhoneNumber { get; set; }
    }
}
