using Infrastructure.DataAccess.EF;
using WS.DataAccess.Implementations.EF.Contexts;
using WS.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Repositories
{
    public class OrderRepository : BaseRepository<Order, NorthwndContext>, IOrderRepository
    {
        public async Task<List<Order>> GetByCityAsync(string city, params string[] includeList)
        {
            return await GetAllAsync(ord=> ord.ShipCity==city,includeList);
        }

        public async Task<List<Order>> GetByCustomerAsync(string customerId, params string[] includeList)
        {
            return await GetAllAsync(ord=> ord.CustomerId==customerId, includeList);
        }

        public async Task<List<Order>> GetByCountryAsync(string country, params string[] includeList)
        {
            return await GetAllAsync(ord=> ord.ShipCountry==country, includeList);
        }

        public  async Task<List<Order>> GetByEmployeeAsync(int employeeId, params string[] includeList)
        {
            return await GetAllAsync(ord=>ord.EmployeeId==employeeId, includeList);
        }

        public async Task<Order> GetByOrderAsync(int orderId, params string[] includeList)
        {
            return await GetAsync(ord=> ord.OrderId==orderId , includeList);

        }

        public async Task<List<Order>> GetByOrderDateAsync(DateTime? orderDate, params string[] includeList)
        {
            return await GetAllAsync(ord=> ord.OrderDate==orderDate , includeList);
        }    

        public async Task<List<Order>> GetDateRangeByOrderAsync(DateTime dateTime1, DateTime dateTime2, params string[] includeList)
        {
            return await GetAllAsync(ord=>ord.OrderDate>=dateTime1 && ord.OrderDate<=dateTime2,includeList);
        }
    }
}

