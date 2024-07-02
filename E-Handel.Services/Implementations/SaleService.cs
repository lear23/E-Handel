
using AutoMapper;
using E_Handel.Dtos;
using E_Handel.Models;
using E_Handel.Repositories.Interfaces;
using E_Handel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Handel.Services.Implementations;

public class SaleService : ISaleService
{
    private readonly ISaleRepo _saleRepo;
    private readonly IMapper _mapper;

    public SaleService(ISaleRepo saleRepo, IMapper mapper)
    {
        _saleRepo = saleRepo;
        _mapper = mapper;
    }

    public async Task<SaleDto> Register(SaleDto model)
    {
        try
        {
            var dbModel = _mapper.Map<Sale>(model);
            var salesBenefits = await _saleRepo.RegisterAsync(dbModel);

            if (salesBenefits.IdSale != 0)                
                throw new TaskCanceledException(" Could not Register.");

            return _mapper.Map<SaleDto>(salesBenefits);

        }
        catch (Exception ex)
        {
            throw new Exception("ERROR: Register SaleService");
        }
    }
}
