

using System.Linq.Expressions;

namespace E_Handel.Repositories.Interfaces;

public interface IGenericRepo<TModel> where TModel : class
{
    IQueryable<TModel> GetAsync(Expression<Func<TModel, bool>>? filter = null);

    Task<TModel> CreateAsync(TModel model);
    Task<bool> UpdateAsync(TModel model);
    Task<bool> DeleteAsync(TModel model);

}
