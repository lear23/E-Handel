

using E_Handel.Models;

namespace E_Handel.Repositories.Interfaces;

public interface ISaleRepo : IGenericRepo<Sale>
{
    Task<Sale> RegisterAsync(Sale model);

}
