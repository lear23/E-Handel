

using AutoMapper;
using E_Handel.Dtos;
using E_Handel.Models;
using E_Handel.Repositories.Interfaces;
using E_Handel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Handel.Services.Implementations;

public class ProductService : IProductService
{

    private readonly IGenericRepo<Product> _modelRepo;
    private readonly IMapper _mapper;

    public ProductService(IGenericRepo<Product> modelRepo, IMapper mapper)
    {
        _modelRepo = modelRepo;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Catalogue(string category, string search)
    {
        try
        {
            var consult = _modelRepo.GetAsync(p => p.ProductName!.ToLower().Contains(search.ToLower()) && p.IdCategoryNavigation!.CategoryName!.ToLower().Contains(search.ToLower()));

            List<ProductDto> list = _mapper.Map<List<ProductDto>>(await consult.ToListAsync());
            return list;
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR: List CustomerService");
        }
    }

    public async Task<ProductDto> Create(ProductDto model)
    {
        try
        {
            var dbModel = _mapper.Map<Product>(model);
            var response = await _modelRepo.CreateAsync(dbModel);

            if (response.IdProduct != 0)
                return _mapper.Map<ProductDto>(response);
            else
                throw new TaskCanceledException(" Could not Create the customer.");

        }
        catch (Exception ex)
        {
            throw new Exception("ERROR: Create CustomerService");
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var consult = _modelRepo.GetAsync(p => p.IdProduct == id);
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
            throw new Exception("ERROR: Delete CustomerService");
        }
    }

    public async Task<ProductDto> Get(int id)
    {
        try
        {
            try
            {
                var consult = _modelRepo.GetAsync(p => p.IdProduct == id);

                var fromDbModel = await consult.FirstOrDefaultAsync();
                if (fromDbModel != null)
                {
                    return _mapper.Map<ProductDto>(fromDbModel);
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

    public async Task<List<ProductDto>> List(string rol, string search)
    {
        try
        {
            var consult = _modelRepo.GetAsync(p => p.ProductName!.ToLower().Contains(search.ToLower()));

            List<ProductDto> list = _mapper.Map<List<ProductDto>>(await consult.ToListAsync());
            return list;
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR: List CustomerService");
        }
    }

    public async Task<bool> Update(ProductDto model)
    {
        try
        {
            var consult = _modelRepo.GetAsync(p => p.IdProduct == model.IdProduct);
            var fromDbModel = await consult.FirstOrDefaultAsync();

            if (fromDbModel != null)
            {
                fromDbModel.ProductName = model.ProductName;
                fromDbModel.IdCategory= model.IdCategory;
                fromDbModel.OfferPrice = model.OfferPrice;
                fromDbModel.Price = model.Price;
                fromDbModel.Description = model.Description;
                fromDbModel.Amount = model.Amount;
                fromDbModel.Image = model.Image;

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
