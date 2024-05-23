using Infrastructure.Utilities;
using System.Xml.Linq;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
  public interface IProductBs
  {
    Task<ApiResponse<List<ProductGetDto>>> GetProductsAsync(params string[] includeList);
    Task<ApiResponse<List<ProductGetDto>>> GetProductsByPriceAsync(decimal min, decimal max, params string[] includeList);
    Task<ApiResponse<List<ProductGetDto>>> GetProductsByStockAsync(short min, short max, params string[] includeList);
    Task<ApiResponse<List<ProductGetDto>>> GetProductsByCategoryAsync(int categoryId, params string[] includeList);
    Task<ApiResponse<ProductGetDto>> GetProductByIdAsync(int productId, params string[] includeList);

    Task<ApiResponse<Product>> InsertAsync (ProductPostDto product);
    Task<ApiResponse<NoData>> UpdateAsync(ProductPutDto product);
    Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
