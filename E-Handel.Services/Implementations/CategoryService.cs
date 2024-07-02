

using AutoMapper;
using E_Handel.Dtos;
using E_Handel.Models;
using E_Handel.Repositories.Interfaces;
using E_Handel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Handel.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepo<Category> _modelRepo;
    private readonly IMapper _mapper;

    public CategoryService(IGenericRepo<Category> modelRepo, IMapper mapper)
    {
        _modelRepo = modelRepo;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Create(CategoryDto model)
    {
        try
        {
            var dbModel = _mapper.Map<Category>(model);
            var response = await _modelRepo.CreateAsync(dbModel);

            if (response.IdCategory != 0)
                return _mapper.Map<CategoryDto>(response);
            else
                throw new TaskCanceledException(" Could not Create the Category.");

        }
        catch (Exception ex)
        {
            throw new Exception("ERROR: Create CategoryService");
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var consult = _modelRepo.GetAsync(p => p.IdCategory == id);
            var fromDbModel = await consult.FirstOrDefaultAsync();

            if (fromDbModel != null)
            {
                var result = await _modelRepo.DeleteAsync(fromDbModel);
                if (!result)
                    throw new TaskCanceledException(" Could not be deleted.");

                return result;
            }
            else { throw new TaskCanceledException("No result found"); }
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR: Delete CategoryService");
        }
    }

    public async Task<CategoryDto> Get(int id)
    {
        try
        {
            try
            {
                var consult = _modelRepo.GetAsync(p => p.IdCategory== id);

                var fromDbModel = await consult.FirstOrDefaultAsync();
                if (fromDbModel != null)
                {
                    return _mapper.Map<CategoryDto>(fromDbModel);
                }
                else
                {
                    throw new TaskCanceledException("No matches found");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: List CustomerService");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR: Get CustomerService");
        }
    }

    public async Task<List<CategoryDto>> List(string search)
    {
        try
        {
            var consult = _modelRepo.GetAsync(p => string.Concat(p.CategoryName!.ToLower()).Contains(search.ToLower()));

            List<CategoryDto> list = _mapper.Map<List<CategoryDto>>(await consult.ToListAsync());
            return list;
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR: List CustomerService");
        }
    }

    public async Task<bool> Update(CategoryDto model)
    {
        try
        {
            var consult = _modelRepo.GetAsync(p => p.IdCategory == model.IdCategory);
            var fromDbModel = await consult.FirstOrDefaultAsync();

            if (fromDbModel != null)
            {
                fromDbModel.CategoryName = model.CategoryName;
               
                var response = await _modelRepo.UpdateAsync(fromDbModel);

                if (!response)
                    throw new TaskCanceledException(" Could not edit the Customer.");
                return response;
            }
            else
            {
                throw new TaskCanceledException(" No results Found.");
            }

        }
        catch (Exception ex)
        {
            throw new Exception("ERROR: Update CustomerService");
        }
    }
}
