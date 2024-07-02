using E_Handel.Dtos;
using E_Handel.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_HandelBlazor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;




    [HttpGet("List/{search:alpha}")]

    public async Task<IActionResult> List(string search = "NA")
    {

        var response = new ResponseDto<List<CategoryDto>>();
        try
        {
            if (search != "NA") search = "";

            response.IsCorrect = true;
            response.Result = await _categoryService.List(search);
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

        var response = new ResponseDto<CategoryDto>();
        try
        {
            response.IsCorrect = true;
            response.Result = await _categoryService.Get(id);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }



    [HttpPost("Create")]

    public async Task<IActionResult> Create([FromBody] CategoryDto dto)
    {

        var response = new ResponseDto<CategoryDto>();
        try
        {


            response.IsCorrect = true;
            response.Result = await _categoryService.Create(dto);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }



    [HttpPut("Update")]

    public async Task<IActionResult> Update([FromBody] CategoryDto dto)
    {

        var response = new ResponseDto<bool>();
        try
        {


            response.IsCorrect = true;
            response.Result = await _categoryService.Update(dto);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }

    [HttpDelete("Delete/{id:int}")]

    public async Task<IActionResult> Delete([FromBody] int id)
    {

        var response = new ResponseDto<bool>();
        try
        {


            response.IsCorrect = true;
            response.Result = await _categoryService.Delete(id);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }


}
