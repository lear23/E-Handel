

namespace E_Handel.Dtos;

public class SaleDto
{
    public int IdSale { get; set; }

    public int? IdCustomer { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<SalesDetailDto> SalesDatails { get; set; } = new List<SalesDetailDto>();

}

