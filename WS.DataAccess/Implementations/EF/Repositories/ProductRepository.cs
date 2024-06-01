using Infrastructure.DataAccess.EF;
using WS.DataAccess.Implementations.EF.Contexts;
using WS.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product, NorthwndContext>, IProductRepository
  {
    public async Task<List<Product>>GetByCategoryAsync(int categoryId, params string[] includeList)
    {
      return await GetAllAsync(prd => prd.CategoryId == categoryId, includeList);
    }

    public async Task<Product> GetByIdAsync(int productId, params string[] includeList)
        {
            return await GetAsync (prd => prd.ProductId == productId, includeList);
        } 

    public async Task<List<Product>> GetByPriceAsync(decimal min, decimal max, params string[] includeList)
    {
      return await GetAllAsync(prd => prd.UnitPrice > min && prd.UnitPrice < max, includeList);
    }   

    public  async Task<List<Product>> GetByStockAsync(short min, short max, params string[] includeList)
    {
      return await GetAllAsync(prd => prd.UnitsInStock > min && prd.UnitsInStock < max, includeList);
    }
  }
}
