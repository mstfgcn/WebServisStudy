using Infrastructure.DataAccess;
using WS.Model.Entities;

namespace WS.DataAccess.Interfaces
{
  public interface IProductRepository:IBaseRepository<Product>
  {
    Task<List<Product>> GetByPriceAsync(decimal min, decimal max, params string[] includeList);
    Task<List<Product>> GetByStockAsync(short min, short max, params string[] includeList);
    Task<List<Product>> GetByCategoryAsync(int categoryId, params string[] includeList);
    Task<Product> GetByIdAsync(int productId, params string[] includeList);

        

  }
}
