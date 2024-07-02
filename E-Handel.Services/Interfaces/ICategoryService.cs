

using E_Handel.Dtos;

namespace E_Handel.Services.Interfaces;

public interface ICategoryService
{

    Task<List<CategoryDto>> List(string search);
    Task<CategoryDto> Get(int id);
    Task<CategoryDto> Create(CategoryDto model);
    Task<bool> Update(CategoryDto model);
    Task<bool> Delete(int id);


}
