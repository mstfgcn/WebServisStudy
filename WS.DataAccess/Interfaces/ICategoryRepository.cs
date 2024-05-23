using Infrastructure.DataAccess;
using WS.Model.Entities;

namespace WS.DataAccess.Interfaces
{
  public interface ICategoryRepository : IBaseRepository<Category>
  {
        
        Task<Category> GetByCategoryId (int categoryId, params string[] includeList);

       
  }
}
