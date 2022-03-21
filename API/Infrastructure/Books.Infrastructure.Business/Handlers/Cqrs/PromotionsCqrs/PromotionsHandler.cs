using AutoMapper;
using Books.Domain.Core.DTOs;
using Books.Domain.Core.Enums;
using Books.Domain.Core.Queries.Promotions;
using Books.Domain.Interfaces.SQL;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.PromotionsCqrs
{
    public class PromotionsHandler : IRequestHandler<PromotionsQuery, List<PromotionDto>>
    {
        private readonly IPromotionsRepository _repository;
        private readonly IMapper _mapper;

        public PromotionsHandler(IPromotionsRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        public async Task<List<PromotionDto>> Handle(PromotionsQuery request, CancellationToken cancellationToken)
        {
            return request.PromotionsType switch
            {
                PromotionsType.Active => _mapper.Map<List<PromotionDto>>(await _repository.Find(x => x.EndDate > DateTime.Now, request.Language, cancellationToken).ConfigureAwait(false)),
                PromotionsType.All => _mapper.Map<List<PromotionDto>>(await _repository.GetAll(request.Language, cancellationToken).ConfigureAwait(false)),
                PromotionsType.Inactive => _mapper.Map<List<PromotionDto>>(await _repository.Find(x => x.EndDate <= DateTime.Now, request.Language, cancellationToken).ConfigureAwait(false)),
                _ => throw new NotImplementedException()
            };
        }
    }
}
