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
           return await GetAsync(ctg =>ctg.CategoryId==categoryId , includeList);
        }

        public async Task<bool> IsCategoryExistsWithName(string categoryName)
        {


            

            var categories = await GetAllAsync(ctg => ctg.CategoryName == categoryName);

            if (categories != null && categories.Count > 0)
                return true;

            return false;
        }

    }
}
