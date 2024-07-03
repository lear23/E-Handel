using E_Handel.Dtos;
using E_HandelBlazor.Services.Interfaces;

namespace E_HandelBlazor.Services.Models
{
    public class SaleModel : ISaleService
    {
        private readonly HttpClient _httpClient;

        public SaleModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDto<SaleDto>> Create(SaleDto model)
        {
            var response = await _httpClient.PostAsJsonAsync("Sale/register", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDto<SaleDto>>();
            return result!;
        }
    }
}
