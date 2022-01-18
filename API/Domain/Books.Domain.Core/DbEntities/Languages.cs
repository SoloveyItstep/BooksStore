using System;

namespace Books.Domain.Core.DbEntities
{
    public class Languages
    {
        public Guid Id { get; set; }
        public string Language { get; set; }
        public string LanguageTitle { get; set; }
    }
}
