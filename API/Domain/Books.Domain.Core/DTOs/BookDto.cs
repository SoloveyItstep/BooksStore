using Books.Domain.Core.DbEntities.Books;
using System;
using System.Collections.Generic;

namespace Books.Domain.Core.DTOs
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public int Code { get; set; }
        public int Count { get; set; }
        public int Year { get; set; }
        public List<string> Images { get; set; }
        public string Language { get; set; }
        public string BookType { get; set; }
        public string Cover { get; set; }
        public string Format { get; set; }
        public string PublHouse { get; set; }
        public string Descr { get; set; }
        public List<BooksRating> BooksRatings { get; set; } 
    }
}
