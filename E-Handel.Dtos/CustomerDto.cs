using System.ComponentModel.DataAnnotations;

namespace E_Handel.Dtos
{
    public class CustomerDto
    {
        public int IdCustomer { get; set; }

        [Required(ErrorMessage = "Enter your first name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Enter your last name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Enter your email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Password must contain at least one letter and one number")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm your password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }

        public string? Rol { get; set; }
    }
}
