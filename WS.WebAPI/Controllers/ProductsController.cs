using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Product;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductBs _productBs;


        public ProductsController(IProductBs productBs)
        {
            _productBs = productBs;

        }

        //K+d

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var response = await _productBs.GetProductsAsync("Category");

            return SendResponse(response);


        }


        [HttpGet("bycategory")]
        public async Task<ActionResult> GetAllProductsByCategory([FromQuery] int categoryId)
        {
            var response = await _productBs.GetProductsByCategoryAsync(categoryId, "Category");
            return SendResponse(response);
        }

        [HttpGet("byprice")]
        // ../api/products/byprice?min=10&max=15  (querystring)
        public async Task<ActionResult> GetAllProductsByPrice([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var response = await _productBs.GetProductsByPriceAsync(min, max, "Category");
            return SendResponse(response);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var response = await _productBs.GetProductByIdAsync(id);
            return SendResponse(response);

        }

        [HttpPost]
        public async Task<ActionResult> SaveNewProduct([FromBody] ProductPostDto dto)
        {

            var response = await _productBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetProductById), new { id = response.Data.ProductId }, response.Data);

        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductPutDto dto)
        {
            var response = await _productBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        //[Produces("application/json", "text/plain")]
        //[ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        //[ProducesResponseType(404, Type = typeof(string))]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var response = await _productBs.DeleteAsync(id);
            return SendResponse(response);
        }


    }
}
