

namespace Infrastructure.Models;

public class Customer
{
    public int IdCustomer { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Rol { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

}
