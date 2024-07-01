using System.ComponentModel.DataAnnotations;

namespace E_Handel.Dtos
{
    public class ProductDto
    {
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Enter the product name")]
        [StringLength(100, ErrorMessage = "Product name cannot be longer than 100 characters")]
        public string? ProductName { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Enter the category ID")]
        public int? IdCategory { get; set; }

        [Required(ErrorMessage = "Enter the price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal? Price { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Offer price must be greater than 0")]
        public decimal? OfferPrice { get; set; }

        [Required(ErrorMessage = "Enter the amount")]
        [Range(0, int.MaxValue, ErrorMessage = "Amount must be a non-negative number")]
        public int? Amount { get; set; }

        [Url(ErrorMessage = "Enter a valid URL for the image")]
        public string? Image { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual CategoryDto? IdCategoryNavigation { get; set; }
    }
}
