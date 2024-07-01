

using System.ComponentModel.DataAnnotations;

namespace E_Handel.Dtos;

public class LoginDto
{


    [Required(ErrorMessage = "Enter your email")]
    [EmailAddress(ErrorMessage = "Enter a valid email address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Enter your password")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Password must contain at least one letter and one number")]
    public string? Password { get; set; }
}
