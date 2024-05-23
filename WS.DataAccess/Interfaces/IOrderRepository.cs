using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Model.Entities;

namespace WS.DataAccess.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>

    {
        //sipariş id üzerinden 1 adet bulmak için
        Task<Order> GetByOrderAsync(int orderId, params string[] includeList);
        //sipariş tarih aralıgı
        Task<List<Order>> GetDateRangeByOrderAsync(DateTime dateTime1 , DateTime dateTime2, params string[] includeList);
        //çalışan id sine ögre
        Task<List<Order>> GetByEmployeeAsync(int employeeId, params string[] includeList);
        //müşteri idsine göre 
        Task<List<Order>> GetByCustomerAsync(string customerId, params string[] includeList);
        //order date göre
        Task<List<Order>> GetByOrderDateAsync(DateTime? orderDate, params string[] includeList);
        //ülkeye göre
        Task<List<Order>> GetByCountryAsync( string country , params string[] includeList);
        //şehre göre
        Task<List<Order>> GetByCityAsync( string city , params string[] includeList);


        //Tümünü getirme ekleme, güncelleme, silme işlerimleri baserepodan çekicez.




    }
}
