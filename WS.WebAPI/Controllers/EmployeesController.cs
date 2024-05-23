
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Employee;



namespace WS.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : BaseController
  {
    private readonly IEmployeeBs _employeeBs;
        

    public EmployeesController(IEmployeeBs employeeBs)
    {
      _employeeBs = employeeBs;


    }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
    {
      
          var dtoList =await _employeeBs.GetAllEmployee("Orders");


            return SendResponse(dtoList);
        }
  }
}
