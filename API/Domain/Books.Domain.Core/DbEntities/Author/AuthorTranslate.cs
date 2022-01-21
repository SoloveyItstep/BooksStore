using System;

namespace Books.Domain.Core.DbEntities.Author
{
    public class AuthorTranslate
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
    }
}
