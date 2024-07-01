using System;
using System.Collections.Generic;

namespace E_Handel.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public int? IdCategory { get; set; }

    public decimal? Price { get; set; }

    public decimal? OfferPrice { get; set; }

    public int? Amount { get; set; }

    public string? Image { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<SalesDatail> SalesDatails { get; set; } = new List<SalesDatail>();
}
