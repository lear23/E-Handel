

using E_Handel.Dtos;

namespace E_Handel.Services.Interfaces
{
    public interface ISaleService 
    {
        Task<SaleDto> Register(SaleDto model);
    
    }
}
