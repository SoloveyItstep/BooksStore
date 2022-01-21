using System;

namespace Books.Domain.Core.DbEntities.Author
{
    public class Author
    {
        public Guid Id { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhotoPath { get; set; }

        public Guid AuthorTranslateId { get; set; }
        public AuthorTranslate AuthorTranslate { get; set; }
    }
}
