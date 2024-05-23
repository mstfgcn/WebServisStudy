using Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Employee;
using WS.Model.Dtos.Order;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {

        private readonly IOrderBs _orderBs;
        public OrdersController(IOrderBs orderBs)
        {

            _orderBs = orderBs;

        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto=await _orderBs.GetByOrderAsync(id,"Employee","Customer","ShipVia");
            return SendResponse(dto);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type= typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        [HttpGet]
        public async Task<ActionResult> GeyByAllOrders()
        {
            var dtoList = await _orderBs.GetByOrdersAsync("Employee", "Customer", "ShippVia ");
            return SendResponse(dtoList);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        [HttpGet("byCountry")]
        public async Task<ActionResult> GetByCountry (string country)
        {
            var dtoList = await _orderBs.GetByCountryAsync(country,"Employee", "Customer", "ShippVia ");
            return SendResponse(dtoList);

        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200,Type=typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(400,Type=typeof(string))]
        [ProducesResponseType(404,Type=typeof(string))]
        [HttpGet("byCity")]
        public async Task<ActionResult> GetByCity (string city)
        {
            var dtoList =await _orderBs.GetByCityAsync(city,"Employee", "Customer", "ShippVia ");
            return SendResponse(dtoList);
        }

        [Produces("application/json","text/plain")]
        [ProducesResponseType(200,Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(400,Type=typeof(string))]
        [ProducesResponseType(404,Type = typeof(string))]
        [HttpGet("byEmployee")]
        public async Task<ActionResult> GetByEmployeeOrders(int employeeId)
        {
            var dtoList =await _orderBs.GetByEmployeeAsync(employeeId, "Customer", "ShippVia");
            return SendResponse(dtoList);
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("byCustomer")]
        public async Task<ActionResult> GetByCustomerOrders(int customerId)
        {
            var dtoList = await _orderBs.GetByEmployeeAsync(customerId, "Customer", "ShippVia");
            return SendResponse(dtoList);
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("byOrderDate")]
        public async Task<ActionResult> GetByEmployeeOrders(DateTime date)
        {
            var dtoList = await _orderBs.GetByOrderDateAsync(date,"Employee", "Customer", "ShippVia");
            return SendResponse(dtoList);
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("byOrderDateRange")]
        public async Task<ActionResult> GetDateRangeByOrderAsync(DateTime date1, DateTime date2)
        {
            var dtoList = await _orderBs.GetDateRangeByOrderAsync(date1, date2, "Employee", "Customer", "ShippVia");
            return SendResponse(dtoList);
        }

        [Produces("application/json", "text/plain")]
        //[ProducesResponseType(200, Type = typeof(ApiResponse<OrderPostDto>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpPost]
        public async Task<ActionResult> InsertOrder(OrderPostDto dto)
        {
            var response = await _orderBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new {id=response.Data.OrderId}, response.Data);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpPut]
        public async Task<ActionResult> UpdateOrder(OrderPutDto dto)
        {
            var dtoList = await _orderBs.UpdateAsync(dto);
            return SendResponse(dtoList);
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var dtoList = await _orderBs.DeleteAsync(id);
            return SendResponse(dtoList);
        }
    }
}
