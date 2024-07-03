using E_Handel.Dtos;
using E_HandelBlazor.Services.Interfaces;

namespace E_HandelBlazor.Services.Models
{
    public class CategoryModel : ICategoyService
    {

        private readonly HttpClient _httpClient;

        public CategoryModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDto<CategoryDto>> Create(CategoryDto model)
        {
            var response = await _httpClient.PostAsJsonAsync("Category/create", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDto<CategoryDto>>();
            return result!;
        }

        public async Task<ResponseDto<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDto<bool>>($"Category/Delete/{id}");
        }

        public async Task<ResponseDto<CategoryDto>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDto<CategoryDto>>($"Category/get/{id}"); ;
        }

        public async Task<ResponseDto<List<CategoryDto>>> List(string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDto<List<CategoryDto>>>($"Category/list/{search}");
        }

        public async Task<ResponseDto<bool>> Update(CategoryDto model)
        {
            var response = await _httpClient.PostAsJsonAsync("Category/Update", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDto<bool>>();
            return result!;
        }
    }
}
