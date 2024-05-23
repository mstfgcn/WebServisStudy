using AutoMapper;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccess.Interfaces;
using WS.Model.Dtos.Order;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class OrderBs : IOrderBs

    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repo;
        public OrderBs(IMapper mapper, IOrderRepository repo)
        {
            _mapper = mapper;

            _repo = repo;

        }

       

        public async Task<ApiResponse<List<OrderGetDto>>> GetByCityAsync(string city, params string[] includeList)
        {
            if (city.Length <= 1)
                throw new BadRequestException("Şehir adı en az 2 karakterden oluşmalıdır.");

            var orders = await _repo.GetByCityAsync(city, includeList);   
            if(orders.Count> 0)
            {
                var response = _mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, response);

            }
            throw new NotFoundException("Kayıt bulunamadı"); 
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetByCountryAsync(string country, params string[] includeList)
        {
            if (country.Length <= 1)
                throw new BadRequestException("Ülke adı 2 en az iki karakter olmalıdır.");
            
            var orders = await _repo.GetByCountryAsync(country, includeList);
            if(orders.Count> 0)
            {
                var response = _mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, response);
            }
            throw new NotFoundException("Kayıt bulunamadı");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetByCustomerAsync(string customerId, params string[] includeList)
        {
            if (customerId.Length != 4)
                throw new BadRequestException("Customer Id hatalıdır.");

            var orders =await _repo.GetByCustomerAsync(customerId, includeList);
            if (orders.Count> 0)
            {
                var response = _mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, response);
            }
            throw new NotFoundException("Kaynak bulunamadı.");

        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetByEmployeeAsync(int employeeId, params string[] includeList)
        {
            if (employeeId == 0)
                throw new BadRequestException("Employee Id hatalıdır.");

            var orders= await _repo.GetByEmployeeAsync(employeeId, includeList);

            if (orders.Count> 0)
            {
                var response = _mapper.Map<List<OrderGetDto>>(orders) ;
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, response);
            }
            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<OrderGetDto>> GetByOrderAsync(int orderId, params string[] includeList)
        {
            if (orderId <= 0)
                throw new BadRequestException("OrderId 0 dan büyük olmalıdır.");
            var orders = await _repo.GetByOrderAsync(orderId, includeList);

            if (orderId > 0)
            {
                var response = _mapper.Map<OrderGetDto>(orders);
                return ApiResponse<OrderGetDto>.Success(StatusCodes.Status200OK, response);
            }
            throw new NotFoundException("kaynak bulunamadı");

        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetByOrderDateAsync(DateTime orderDate, params string[] includeList)
        {
            if (orderDate == null)
                throw new BadRequestException("Tarih kısmı boş olamaz.");

            var orders = await _repo.GetByOrderDateAsync(orderDate, includeList);
            if (orders.Count > 0)
            {
                var response =_mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, response);
            }
            throw new NotFoundException("Kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetByOrdersAsync(params string[] includeList)
        {
            var orders =await _repo.GetAllAsync(includeList:includeList);
            if(orders.Count >0)
            {
                var response=_mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, response);
            }
            throw new NotFoundException("Kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetDateRangeByOrderAsync(DateTime date1, DateTime date2, params string[] includeList)
        {
            if (date1 == null || date2 == null)
                throw new BadRequestException("Tarihler boş olamaz");
            var orders = await _repo.GetDateRangeByOrderAsync(date1, date2, includeList);
            if (orders.Count > 0)
            {
                var response= _mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, response);
            }
            throw new NotFoundException("Kaynak bulunamadı");
        }

        public async Task<ApiResponse<Order>> InsertAsync(OrderPostDto orderPost)
        {
            if (orderPost.CustomerId == null)
                throw new BadRequestException("CustomerID boş olamaz.");
            if (orderPost.EmployeeId == 0)
                throw new BadRequestException("EmployeeId boş olamaz.");
            if (orderPost.OrderDate == null)
                throw new BadRequestException("Sipariş tarihi boş olamaz.");
            if (orderPost.ShipVia == null)
                throw new BadRequestException("Gönderim türü boş olamaz.");
            if (orderPost.ShipName == null)
                throw new BadRequestException("İsim kısmı boş olamaz.");
            if (orderPost.ShipCity == null)
                throw new BadRequestException("şehir kısmı boş olamaz.");
            if (orderPost.ShipCountry == null)
                throw new BadRequestException("ülke kısmı boş olamaz.");
            if (orderPost.ShipAddress == null)
                throw new BadRequestException("Adres boş olamaz.");
            if (orderPost.Freight == 0)
                throw new BadRequestException("Lütfen agırlıgını giriniz");

            var order = _mapper.Map<Order>(orderPost);
            var inserted=await _repo.InsertAsync(order);
            return ApiResponse<Order>.Success(StatusCodes.Status201Created,inserted );
            
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(OrderPutDto orderPut)
        {
            if(orderPut.OrderId<= 0)
                throw new BadRequestException("Id pozitif olmalıdır");
            if (orderPut.EmployeeId <= 0)
                throw new BadRequestException("Id pozitif olmalıdır");
            if (orderPut.CustomerId == null)
                throw new BadRequestException("Id pozitif olmalıdır");
            if (orderPut.ShipVia <= 0)
                throw new BadRequestException("Kargo turu seçilmesi zorunludur.");
            if (orderPut.ShipName == null)
                throw new BadRequestException("Alıcı adı boş olamaz");
            if (orderPut.ShipCountry == null)
                throw new BadRequestException("alıcı şehir alanı boş olamaz");
            if (orderPut.ShipAddress == null)
                throw new BadRequestException("adres kısmı boş olamaz");
            var entity= _mapper.Map<Order>(orderPut);
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);




            throw new BadRequestException("Id pozitif olmalıdır");
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new NotFoundException("Id pozitif bir değer olmalıdır");
            var product = await _repo.GetByOrderAsync(id);
            await _repo.DeleteAsync(product);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
