using AutoMapper;
using Books.Domain.Core.DbEntities.PromotionsModels;
using Books.Domain.Core.DTOs;
using System.Linq;

namespace Books.Infrastructure.Business.Configuration
{
    public class AutomapperConfigProfile: Profile
    {
        public AutomapperConfigProfile()
        {
            // Promotions
            CreateMap<Promotions, PromotionsDto>()
                .ForMember(dest => dest.Description, output => output.MapFrom(target =>
                     target.PromotionsTranslates == null || !target.PromotionsTranslates.Any()
                        ? string.Empty
                        : target.PromotionsTranslates.First().Description
                ))
                .ForMember(dest => dest.ShortTitle, output => output.MapFrom(target =>
                     target.PromotionsTranslates == null || !target.PromotionsTranslates.Any()
                        ? string.Empty
                        : target.PromotionsTranslates.First().ShortTitle
                ))
                .ForMember(dest => dest.Title, output => output.MapFrom(target =>
                     target.PromotionsTranslates == null || !target.PromotionsTranslates.Any()
                        ? string.Empty
                        : target.PromotionsTranslates.First().Title
                ))
                .ForMember(dest => dest.ShortDescription, output => output.MapFrom(target =>
                     target.PromotionsTranslates == null || !target.PromotionsTranslates.Any()
                        ? string.Empty
                        : target.PromotionsTranslates.First().ShortDescription
                ));
        }
    }
}
