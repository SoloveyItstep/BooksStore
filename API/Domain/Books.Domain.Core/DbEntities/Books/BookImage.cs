using System;

namespace Books.Domain.Core.DbEntities.Books
{
    public class BookImage
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public bool IsMain { get; set; }
    }
}
