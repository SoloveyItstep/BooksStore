using System.Collections.Generic;

namespace Books.Domain.Core.DTOs
{
    public class FavotitesDto
    {
        public IEnumerable<string> BooksIds { get; set; }
    }
}
