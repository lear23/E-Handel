
using AutoMapper;
using E_Handel.Dtos;
using E_Handel.Models;
using E_Handel.Repositories.Interfaces;
using E_Handel.Services.Interfaces;

namespace E_Handel.Services.Implementations;

public class DashboardService(ISaleRepo saleRepo, IGenericRepo<Customer> userRepo, IGenericRepo<Product> productRepo) : IDashboardService
{

    private readonly ISaleRepo _saleRepo = saleRepo;
    private readonly IGenericRepo<Customer> _userRepo = userRepo;
    private readonly IGenericRepo<Product> _productRepo = productRepo;


    private string Income()
    {
        var consult = _saleRepo.GetAsync();
        decimal? income = consult.Sum(x => x.Total);
        return Convert.ToString(income)!;
    }

    private int Sales()
    {
        var consult = _saleRepo.GetAsync();
        int total = consult.Count();
        return total;
    }
    private int Customers()
    {
        var consult = _userRepo.GetAsync(u => u.Rol.ToLower() == "Customer");
        int total = consult.Count();
        return total;
    }

    private int Products()
    {
        var consult = _productRepo.GetAsync();
        int total = consult.Count();
        return total;
    }

    public DashBoardDto Summary()
    {
        try
        {
            DashBoardDto dto = new DashBoardDto() 
            {
                TotalIncome = Income(),
                TotalSale = Sales(),
                TotalCustomer = Customers(),
                TotalProducts = Products(),
             
            };
            return dto;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}
