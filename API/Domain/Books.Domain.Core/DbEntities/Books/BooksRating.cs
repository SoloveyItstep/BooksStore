using Books.Domain.Core.Identity;
using System;

namespace Books.Domain.Core.DbEntities.Books
{
    public class BooksRating
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
