using System;

namespace Books.Domain.Core.DTOs
{
    public class PromotionDto
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}
