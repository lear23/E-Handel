using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Sale
{
    public int IdSale { get; set; }

    public int? IdCustomer { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual Customer? IdCustomerNavigation { get; set; }

    public virtual ICollection<SalesDatail> SalesDatails { get; set; } = new List<SalesDatail>();
}
