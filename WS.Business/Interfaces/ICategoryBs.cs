using Infrastructure.Utilities;
using WS.Model.Dtos.Category;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface ICategoryBs
    {
        Task<ApiResponse<List<CategoryGetDto>>> GetAllCategoryAsync(params string[] includeList);
        Task<ApiResponse<CategoryGetDto>> GetCategoryAsync(int categoryId, params string[] includeList);

        Task<ApiResponse<Category>>InsertAsync(CategoryPostDto category);
        Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto category);
        Task <ApiResponse<NoData>>DeleteAsync (int categoryId);
    }
}
