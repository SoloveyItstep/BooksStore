using System;

namespace Books.Domain.Core.DbEntities.Books
{
    public class BooksCoverTranslate
    {
        public Guid Id { get; set; }
        public string Cover { get; set; }

        public Guid LangId { get; set; }
        public Languages Languages { get; set; }
    }
}
