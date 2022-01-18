using System;

namespace Books.Domain.Core.DbEntities.PromotionsModels
{
    public class PromotionsTranslate
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public Guid PromotionsId { get; set; }
        public virtual Promotions Promotions { get; set; }

        public Guid LanguagesId { get; set; }
        public virtual Languages Languages { get; set; }
    }
}
