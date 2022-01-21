using System;

namespace Books.Domain.Core.DbEntities.Books
{
    public class BooksLanguageTranslate
    {
        public Guid Id { get; set; }
        public string Lang { get; set; }

        public Guid LangualeId { get; set; }
        public Languages Language { get; set; }
    }
}
