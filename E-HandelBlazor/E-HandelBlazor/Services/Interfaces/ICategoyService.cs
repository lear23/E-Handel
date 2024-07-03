using E_Handel.Dtos;

namespace E_HandelBlazor.Services.Interfaces
{
    public interface ICategoyService
    {

        Task<ResponseDto<List<CategoryDto>>> List(string search);
        Task<ResponseDto<CategoryDto>> Get(int id);
        Task<ResponseDto<CategoryDto>> Create(CategoryDto model);
        Task<ResponseDto<bool>> Update(CategoryDto model);
        Task<ResponseDto<bool>> Delete(int id);
    }
}
