using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Domain.Core.DbEntities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
