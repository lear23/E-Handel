using E_Handel.Dtos;
using E_HandelBlazor.Services.Interfaces;
using System.Reflection;

namespace E_HandelBlazor.Services.Models;

public class CustomerModel(HttpClient httpClient) : ICustomerModel
{
    private readonly HttpClient _httpClient = httpClient;



    public async Task<ResponseDto<SessionDto>> Auth(LoginDto model)
    {
        var response = await _httpClient.PostAsJsonAsync("Customer/Auth", model);
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<SessionDto>>();
        return result!;
    }
    public async Task<ResponseDto<CustomerDto>> Create(CustomerDto model)
    {
        var response = await _httpClient.PostAsJsonAsync("Customer/create", model);
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<CustomerDto>>();
        return result!;
    }

    public async Task<ResponseDto<bool>> Delete(int id)
    {
     return await _httpClient.DeleteFromJsonAsync<ResponseDto<bool>>($"Customer/Delete/{id}");
        
    }

    public async Task<ResponseDto<CustomerDto>> Get(int id)
    {
        return await _httpClient.GetFromJsonAsync<ResponseDto<CustomerDto>>($"Customer/Get/{id}");
    }

    public async Task<ResponseDto<List<CustomerDto>>> List(string rol, string search)
    {
        return await _httpClient.GetFromJsonAsync<ResponseDto<List<CustomerDto>>>($"Customer/list/{rol}/{search}");
    }

    public async Task<ResponseDto<bool>> Update(CustomerDto model)
    {
        var response = await _httpClient.PostAsJsonAsync("Customer/Update", model);
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<bool>>();
        return result!;
    }
}
