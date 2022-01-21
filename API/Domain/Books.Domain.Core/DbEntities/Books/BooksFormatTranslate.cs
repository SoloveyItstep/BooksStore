using System;

namespace Books.Domain.Core.DbEntities.Books
{
    public class BooksFormatTranslate
    {
        public Guid Id { get; set; }
        public string Format { get; set; }

        public Guid LangId { get; set; }
        public Languages Languages { get; set; }
    }
}
