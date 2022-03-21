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
    public class PromotionsShortHandler: IRequestHandler<PromotionsShortQuery, List<PromotionShortDto>>
    {
        private readonly IPromotionsRepository _repository;
        private readonly IMapper _mapper;

        public PromotionsShortHandler(IPromotionsRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        public async Task<List<PromotionShortDto>> Handle(PromotionsShortQuery request, CancellationToken cancellationToken)
        {
            return request.PromotionsType switch
            {
                PromotionsType.Active => _mapper.Map<List<PromotionShortDto>>(await _repository.Find(x => x.EndDate > DateTime.Now, request.Language, cancellationToken).ConfigureAwait(false)),
                PromotionsType.All => _mapper.Map<List<PromotionShortDto>>(await _repository.GetAll(request.Language, cancellationToken).ConfigureAwait(false)),
                PromotionsType.Inactive => _mapper.Map<List<PromotionShortDto>>(await _repository.Find(x => x.EndDate <= DateTime.Now, request.Language, cancellationToken).ConfigureAwait(false)),
                _ => throw new NotImplementedException()
            };
        }
    }
}
