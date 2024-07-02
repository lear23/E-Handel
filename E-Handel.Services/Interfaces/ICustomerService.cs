
using E_Handel.Dtos;

namespace E_Handel.Services.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerDto>> List(string rol, string search);
    Task<CustomerDto> Get(int id);
    Task<SessionDto> Auth(LoginDto model);
    Task<CustomerDto> Create(CustomerDto model);
    Task<bool> Update(CustomerDto model);
    Task<bool> Delete(int id);

}
