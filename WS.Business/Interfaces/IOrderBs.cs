using Infrastructure.Utilities;
using WS.Model.Dtos.Order;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IOrderBs
    {
        Task<ApiResponse<List<OrderGetDto>>> GetByOrdersAsync(params string[] includeList);
        Task<ApiResponse<OrderGetDto>> GetByOrderAsync(int orderId, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetDateRangeByOrderAsync(DateTime date1, DateTime date2, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetByEmployeeAsync(int employeeId,params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetByCustomerAsync(string customerId, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetByOrderDateAsync(DateTime orderDate, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetByCityAsync(string city, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetByCountryAsync(string country, params string[] includeList);


        Task<ApiResponse<Order>> InsertAsync(OrderPostDto orderPost);
        Task<ApiResponse<NoData>> UpdateAsync(OrderPutDto orderPut);
        Task<ApiResponse<NoData>> DeleteAsync(int id);


    }
}
