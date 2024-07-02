using E_Handel.Dtos;
using E_Handel.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_HandelBlazor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerService userService) : ControllerBase
{

    private readonly ICustomerService _userService = userService;

    [HttpGet("List/{rol:alpha}/{search:alpha?}")]

    public async Task<IActionResult> List(string rol, string search = "NA")
    {

        var response = new ResponseDto<List<CustomerDto>>();
        try
        {
            if (search != "NA") search = ""; 

            response.IsCorrect = true;
            response.Result = await _userService.List(rol, search);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }





    [HttpGet("Get/{id:int}")]

    public async Task<IActionResult> Get(int id)
    {

        var response = new ResponseDto<CustomerDto>();
        try
        {
     

            response.IsCorrect = true;
            response.Result = await _userService.Get(id);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }


    [HttpPost("Create")]

    public async Task<IActionResult> Create([FromBody]CustomerDto dto)
    {

        var response = new ResponseDto<CustomerDto>();
        try
        {


            response.IsCorrect = true;
            response.Result = await _userService.Create(dto);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }


    [HttpPost("Auth")]

    public async Task<IActionResult> Auth([FromBody] LoginDto dto)
    {

        var response = new ResponseDto<SessionDto>();
        try
        {


            response.IsCorrect = true;
            response.Result = await _userService.Auth(dto);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }


    [HttpPut("Update")]

    public async Task<IActionResult> Update([FromBody] CustomerDto dto)
    {

        var response = new ResponseDto<bool>();
        try
        {


            response.IsCorrect = true;
            response.Result = await _userService.Update(dto);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }

    [HttpDelete("Delete/{id:int}\")")]

    public async Task<IActionResult> Delete([FromBody] int id)
    {

        var response = new ResponseDto<bool>();
        try
        {


            response.IsCorrect = true;
            response.Result = await _userService.Delete(id);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }


}
