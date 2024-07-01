

using System.ComponentModel.DataAnnotations;

namespace E_Handel.Dtos;

public class CategoryDto
{
    public int IdCategory { get; set; }

    [Required(ErrorMessage = "Enter name")]
    public string? CategoryName { get; set; }

}
