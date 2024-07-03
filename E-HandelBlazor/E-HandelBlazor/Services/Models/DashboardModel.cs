using E_Handel.Dtos;
using E_HandelBlazor.Services.Interfaces;

namespace E_HandelBlazor.Services.Models
{
    public class DashboardModel : IDashboardService
    {

        private readonly HttpClient _httpClient;

        public DashboardModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDto<DashboardDto>> Get()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDto<DashboardDto>>($"Dashboard/Summary");
        }
    }
}
