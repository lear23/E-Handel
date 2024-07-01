

using System.ComponentModel.DataAnnotations;

namespace E_Handel.Dtos;

public class CardDto
{
    [Required(ErrorMessage = "The card holder's name is required")]
    public string? Holder { get; set; }

    [Required(ErrorMessage = "The card number is required")]
    public string? Number { get; set; }

    [Required(ErrorMessage = "The validity date is required")]
    public string? Validity { get; set; }

    [Required(ErrorMessage = "The CVV code is required")]
    public string? CVV { get; set; }

}
