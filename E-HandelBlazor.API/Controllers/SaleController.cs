using E_Handel.Dtos;
using E_Handel.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_HandelBlazor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController(ISaleService saleService) : ControllerBase
{

    private readonly ISaleService _saleService = saleService;




    [HttpPost("Register")]

    public async Task<IActionResult> Register([FromBody] SaleDto dto)
    {

        var response = new ResponseDto<SaleDto>();
        try
        {


            response.IsCorrect = true;
            response.Result = await _saleService.Register(dto);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }

}
