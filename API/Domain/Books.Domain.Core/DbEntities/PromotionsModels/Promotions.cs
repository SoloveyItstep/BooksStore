using System;
using System.Collections.Generic;

namespace Books.Domain.Core.DbEntities.PromotionsModels
{
    public class Promotions
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImagePath { get; set; }
        public virtual List<PromotionsTranslate> PromotionsTranslates { get; set; }
    }
}
