using Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Category;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryBs _categoryBs;

        public CategoriesController(ICategoryBs categoryBs)
        {
            _categoryBs = categoryBs;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet]
        public async Task<ActionResult> GetAllCategory()
        {
            var response = await _categoryBs.GetAllCategoryAsync("Products");
            return SendResponse(response);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<CategoryGetDto>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var response = await _categoryBs.GetCategoryAsync(id, "Products");
            return SendResponse(response);
        }

        [Produces ("applicaiton/json", "text/plain")]
        [ProducesResponseType(201,Type=typeof(ApiResponse<CategoryGetDto>))]
        [ProducesResponseType(400,Type= typeof(string))]
        [HttpPost]
        public async Task<ActionResult> SaveNewCategory(CategoryPostDto dto)
        {
            var entity =await _categoryBs.InsertAsync(dto);
            return CreatedAtRoute(nameof(GetById),new {id=entity.Data.CategoryId}, entity.Data);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpPut]
        public async Task<ActionResult> UpdateCategory (CategoryPutDto dto)
        {
            var response =await _categoryBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var dtoList = await _categoryBs.DeleteAsync(id);
            return SendResponse(dtoList);
        }
    }
}
