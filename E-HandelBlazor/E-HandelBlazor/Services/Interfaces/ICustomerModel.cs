using E_Handel.Dtos;

namespace E_HandelBlazor.Services.Interfaces;

public interface ICustomerModel
{
    Task<ResponseDto<List<CustomerDto>>> List( string rol, string search);
    Task<ResponseDto<CustomerDto>> Get(int id);
    Task<ResponseDto<SessionDto>> Auth(LoginDto model);
    Task<ResponseDto<CustomerDto>> Create(CustomerDto model);
    Task<ResponseDto<bool>> Update(CustomerDto model);
    Task<ResponseDto<bool>> Delete(int id);

}
