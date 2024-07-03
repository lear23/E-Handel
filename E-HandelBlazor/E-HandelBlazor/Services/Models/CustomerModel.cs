using E_Handel.Dtos;
using E_HandelBlazor.Services.Interfaces;

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
    public Task<ResponseDto<CustomerDto>> Create(CustomerDto model)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<bool>> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<CustomerDto>> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<List<CustomerDto>>> List(string rol, string search)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<bool>> Update(CustomerDto model)
    {
        throw new NotImplementedException();
    }
}
