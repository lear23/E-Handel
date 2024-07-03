using E_Handel.Dtos;
using E_HandelBlazor.Services.Interfaces;

namespace E_HandelBlazor.Services.Models
{
    public class ProductModel : IProductService
    {
        
        private readonly HttpClient _httpClient;

        public ProductModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDto<List<ProductDto>>> Catalogue(string category, string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDto<List<ProductDto>>>($"Product/catalogue/{category}/{search}");
        }

        public async Task<ResponseDto<ProductDto>> Create(ProductDto model)
        {
            var response = await _httpClient.PostAsJsonAsync("Producto/create", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDto<ProductDto>>();
            return result!;
        }

        public async Task<ResponseDto<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDto<bool>>($"Product/Delete/{id}");
        }

        public async Task<ResponseDto<ProductDto>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDto<ProductDto>>($"Product/Get/{id}");
        }

        public async Task<ResponseDto<List<ProductDto>>> List(string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDto<List<ProductDto>>>($"Product/list/{search}");
        }

        public async Task<ResponseDto<bool>> Update(ProductDto model)
        {
            var response = await _httpClient.PostAsJsonAsync("Product/Update", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDto<bool>>();
            return result!;
        }
    }
}
