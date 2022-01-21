using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Domain.Core.DbEntities.Books
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public int Code { get; set; }
        public int Count { get; set; }
        public int Year { get; set; }

        public virtual List<BookImage> BooksImages { get; set; }
        public virtual List<BooksLanguageTranslate> BooksLanguageTranslates { get; set; }
        public virtual List<BooksTypeTranslate> BooksTypeTranslates { get; set; }
        public virtual List<BooksCoverTranslate> BooksCoverTranslates { get; set; }
        public virtual List<BooksFormatTranslate> BooksFormatTranslates { get; set; }
        public virtual List<BooksTranslate> BooksTranslates { get; set; }
        public virtual List<BooksRating> BooksRatings { get; set; }

        public Guid BooksPublishmentHouseId { get; set; }
        public BooksPublishmentHouse BooksPublishmentHouse { get; set; }



    }
}
