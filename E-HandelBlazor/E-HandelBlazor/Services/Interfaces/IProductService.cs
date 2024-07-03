using E_Handel.Dtos;

namespace E_HandelBlazor.Services.Interfaces;

public interface IProductService
{


    Task<ResponseDto<List<ProductDto>>> List(string search);
    Task<ResponseDto<List<ProductDto>>> Catalogue(string category, string search);
    Task<ResponseDto<ProductDto>> Get(int id);
    Task<ResponseDto<ProductDto>> Create(ProductDto model);
    Task<ResponseDto<bool>> Update(ProductDto model);
    Task<ResponseDto<bool>> Delete(int id);

}
