using System;

namespace Books.Domain.Core.DbEntities.Books
{
    public class BooksTypeTranslate
    {
        public Guid Id { get; set; }
        public string BookType { get; set; }

        public Guid LangId { get; set; }
        public Languages Languages { get; set; }
    }
}
