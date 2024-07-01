

using AutoMapper;
using E_Handel.Dtos;
using E_Handel.Models;

namespace E_Handel.Mappings;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<Customer, SessionDto>();
        CreateMap<CustomerDto, Customer>();

        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();

        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>().ForMember(x => x.IdCategoryNavigation, opt => opt.Ignore()); //Man gör detta för att ignorera ' public virtual CategoryDto? IdCategoryNavigation { get; set; }'

        CreateMap<SalesDetail, SalesDetailDto>();
        CreateMap<SalesDetailDto, SalesDetail>();

        CreateMap<Sale, SaleDto>();
        CreateMap<SaleDto, Sale>();

    }

}
