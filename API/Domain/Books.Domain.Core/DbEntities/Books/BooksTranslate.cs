using System;

namespace Books.Domain.Core.DbEntities.Books
{
    public class BooksTranslate
    {
        public Guid Id { get; set; }
        public string Desc { get; set; }
        public string ShortDesc { get; set; }

        public Guid LangId { get; set; }
        public Languages Languages { get; set; }
    }
}
