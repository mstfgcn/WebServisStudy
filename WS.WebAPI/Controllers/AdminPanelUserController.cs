using Infrastructure.Utilities;
using Infrastructure.Utilities.Security.JWT;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.AdminPanelUser;
using WS.Model.Dtos.Employee;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPanelUserController :BaseController
    {
        private readonly IAdminPanelUserBs _adminBs;
        private readonly IConfiguration _configuration;

        public AdminPanelUserController(IAdminPanelUserBs adminBs, IConfiguration configuration)
        {
            _adminBs = adminBs;
            _configuration = configuration;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AccesToken>))]
        
        [HttpGet("gettoken")]
        public async Task<IActionResult> GetToken()
        {
            var accesToken= new JwtGenerator(_configuration).GenerateAccesToken();
            var response = new ApiResponse<AccesToken>();
            response.StatusCode = 200;
            response.Data = accesToken;

            return SendResponse(response);

        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<AdminPanelUserDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("login")]
        public async Task<IActionResult> LogIn([FromQuery]string userName, [FromQuery] string password)
        {
            var response =await _adminBs.GetUserNameAndPasswordAsync(userName, password);
            return SendResponse(response);

        }
    }
}
