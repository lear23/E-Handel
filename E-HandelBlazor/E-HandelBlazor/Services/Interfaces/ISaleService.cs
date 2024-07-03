using E_Handel.Dtos;

namespace E_HandelBlazor.Services.Interfaces
{
    public interface ISaleService
    {
        Task<ResponseDto<SaleDto>> Create(SaleDto model);
    }
}
