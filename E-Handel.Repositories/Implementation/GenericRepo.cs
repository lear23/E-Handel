using E_Handel.Repositories.DBContext;
using E_Handel.Repositories.Interfaces;
using System.Linq.Expressions;

namespace E_Handel.Repositories.Implementation;

public class GenericRepo<TModel>(DbEHandelContext dbContext) : IGenericRepo<TModel> where TModel : class
{
  
    private readonly DbEHandelContext _dbContext = dbContext;



    public IQueryable<TModel> GetAsync(Expression<Func<TModel, bool>>? filter = null)
    {
        IQueryable<TModel> consult = (filter == null) ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filter);
        return consult;


    }


    public async Task<TModel> CreateAsync(TModel model)
    {
        try
        {
            _dbContext.Set<TModel>().Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> DeleteAsync(TModel model)
    {
        try
        {
            _dbContext.Set<TModel>().Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> UpdateAsync(TModel model)
    {
        try
        {
            _dbContext.Set<TModel>().Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
