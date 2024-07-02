using E_Handel.Dtos;
using E_Handel.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_HandelBlazor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController(IDashboardService service) : ControllerBase
{
    private readonly IDashboardService _service = service;



    [HttpGet("Summary")]

    public  IActionResult Summary()
    {

        var response = new ResponseDto<DashboardDto>();
        try
        {
            response.IsCorrect = true;
            response.Result = _service.Summary();
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }
}
