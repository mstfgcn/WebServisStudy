using Infrastructure.DataAccess.EF;
using WS.DataAccess.Implementations.EF.Contexts;
using WS.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Repositories
{
  public class CategoryRepository : BaseRepository<Category, NorthwndContext>, ICategoryRepository
  {

        public async Task<Category> GetByCategoryId(int categoryId, params string[] includeList)
        {
           return await GetAsync(ctg => ctg.CategoryId == categoryId , includeList);
        }

    }
}
