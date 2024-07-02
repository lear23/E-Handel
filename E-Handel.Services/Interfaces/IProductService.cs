

using E_Handel.Dtos;

namespace E_Handel.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> List(string rol, string search);
        Task<List<ProductDto>> Catalogue(string category, string search);
        Task<ProductDto> Get(int id);
        Task<ProductDto> Create(ProductDto model);
        Task<bool> Update(ProductDto model);
        Task<bool> Delete(int id);

    }
}
