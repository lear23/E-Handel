

using E_Handel.Models;
using E_Handel.Repositories.DBContext;
using E_Handel.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Handel.Repositories.Implementation
{
    public class SaleRepo : GenericRepo<Sale>, ISaleRepo
    {
        private readonly DbEHandelContext _dbContext;

        public SaleRepo(DbEHandelContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Sale> RegisterAsync(Sale model)
        {
            Sale generatedSale = new Sale();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {                   

                    foreach (SalesDetail ds in model.SalesDatails)
                    {
                        Product product_find = await _dbContext.Products.Where(p => p.IdProduct == ds.IdProduct).FirstAsync();

                        product_find.Amount = product_find.Amount - ds.Amount;
                        _dbContext.Products.Update(product_find);
                    }
                    await _dbContext.SaveChangesAsync();

                    await _dbContext.Sales.AddAsync(model);
                    await _dbContext.SaveChangesAsync();
                    generatedSale = model;
                    transaction.Commit();
                }
                catch 
                {
                   transaction.Rollback();
                }
            }

            return generatedSale;

        }
    }
}
