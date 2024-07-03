using E_Handel.Dtos;

namespace E_HandelBlazor.Services.Interfaces;

public interface IDashboardService
{

    Task<ResponseDto<DashboardDto>> Get();
}
