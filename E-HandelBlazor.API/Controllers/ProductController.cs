using E_Handel.Dtos;
using E_Handel.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_HandelBlazor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{

    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("List/{search:alpha?}")]
    public async Task<IActionResult> List(string search = "NA")
    {

        var response = new ResponseDto<List<ProductDto>>();
        try
        {
            if (search != "NA") search = "";

            response.IsCorrect = true;
            response.Result = await _productService.List(search);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }


    [HttpGet("Catalogue/{category:alpha}/{search:alpha?}")]

    public async Task<IActionResult> Catalogue(string category, string search = "NA")
    {

        var response = new ResponseDto<List<ProductDto>>();
        try
        {
            if (category.ToLower() != "all") category = "";
            if (search != "NA") search = "";

            response.IsCorrect = true;
            response.Result = await _productService.Catalogue(category, search);
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

        var response = new ResponseDto<ProductDto>();
        try
        {


            response.IsCorrect = true;
            response.Result = await _productService.Get(id);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }


    [HttpPost("Create")]

    public async Task<IActionResult> Create([FromBody] ProductDto dto)
    {

        var response = new ResponseDto<ProductDto>();
        try
        {
            response.IsCorrect = true;
            response.Result = await _productService.Create(dto);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }

    [HttpPut("Update")]

    public async Task<IActionResult> Update([FromBody] ProductDto dto)
    {

        var response = new ResponseDto<bool>();
        try
        {


            response.IsCorrect = true;
            response.Result = await _productService.Update(dto);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }

    [HttpDelete("Delete/{id:int})")]

    public async Task<IActionResult> Delete([FromBody] int id)
    {

        var response = new ResponseDto<bool>();
        try
        {


            response.IsCorrect = true;
            response.Result = await _productService.Delete(id);
        }
        catch (Exception ex)
        {
            response.IsCorrect = false;
            response.Message = ex.Message;
        }
        return Ok(response);

    }




}
