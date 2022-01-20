using Books.Domain.Core.DTOs;
using Books.Domain.Core.Enums;
using MediatR;
using System.Collections.Generic;

namespace Books.Domain.Core.Queries.Promotions
{
    public  class PromotionsQuery: IRequest<List<PromotionsDto>>
    {
        public PromotionsType PromotionsType { get; set; }
        public string Language { get; set; }
    }
}
