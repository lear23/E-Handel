

using AutoMapper;
using E_Handel.Dtos;
using E_Handel.Models;
using E_Handel.Repositories.Interfaces;
using E_Handel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Handel.Services.Implementations;

public class CustomerService : ICustomerService
{
    
    private readonly IGenericRepo<Customer> _modelRepo;
    private readonly IMapper _mapper;

    public CustomerService(IGenericRepo<Customer> modelRepo, IMapper mapper)
    {
        _modelRepo = modelRepo;
        _mapper = mapper;
    }

    public async Task<SessionDto> Auth(LoginDto model)
    {
        try
        {
            var consult = _modelRepo.GetAsync(p => p.Email == model.Email && p.Password == model.Password);
            var fromDbModel = await consult.FirstOrDefaultAsync();
            if (fromDbModel != null)
            {
                return _mapper.Map<SessionDto>(fromDbModel);
            }
            else
            {
                throw new TaskCanceledException(" No matches found.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR: Auth CustomerService");
        }
    }

    public async Task<CustomerDto> Create(CustomerDto model)
    {
        try
        {
            var dbModel= _mapper.Map<Customer>(model);
            var response = await _modelRepo.CreateAsync(dbModel);

            if (response.IdCustomer != 0)
                return _mapper.Map<CustomerDto>(response);
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
            var consult = _modelRepo.GetAsync(p => p.IdCustomer == id);
            var fromDbModel = await consult.FirstOrDefaultAsync();

            if (fromDbModel != null)
            {
                var result = await _modelRepo.DeleteAsync(fromDbModel);
                if(!result)
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

    public async Task<CustomerDto> Get(int id)
    {
        try
        {
            try
            {
                var consult = _modelRepo.GetAsync(p => p.IdCustomer == id);

                var fromDbModel = await consult.FirstOrDefaultAsync();   
                if (fromDbModel != null)
                {
                    return _mapper.Map<CustomerDto>(fromDbModel);
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

    public async Task<List<CustomerDto>> List(string rol, string search)
    {
        try
        {
            var consult = _modelRepo.GetAsync(p => p.Rol == rol && string.Concat(p.FirstName!.ToLower(),p.LastName!.ToLower(),p.Email!.ToLower()).Contains(search.ToLower()));

            List<CustomerDto> list = _mapper.Map<List<CustomerDto>>(await consult.ToListAsync());
            return list;
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR: List CustomerService");
        }
    }

    public async Task<bool> Update(CustomerDto model)
    {
        try
        {
            var consult = _modelRepo.GetAsync(p => p.IdCustomer == model.IdCustomer);
            var fromDbModel = await consult.FirstOrDefaultAsync();

            if (fromDbModel != null)
            {
                fromDbModel.FirstName = model.FirstName;
                fromDbModel.LastName = model.LastName;
                fromDbModel.Email = model.Email;
                fromDbModel.Password = model.Password;
                var response = await _modelRepo.UpdateAsync(fromDbModel);

                if(!response)
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
