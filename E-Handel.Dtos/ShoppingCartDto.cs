

namespace E_Handel.Dtos;

public class ShoppingCartDto
{

    public ProductDto? Product { get; set; }
    public int? Amount { get; set; } 
    public decimal? Price { get; set; }
    public decimal? Total { get; set; }

}
