using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class GetSaleResultProfile : Profile
{
    public GetSaleResultProfile()
    {
        CreateMap<SaleEntity, GetSaleResult>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
    }
}