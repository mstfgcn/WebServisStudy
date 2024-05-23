using Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace WS.WebAPI.Controllers
{
    public class BaseController:ControllerBase
    {
        [NonAction]
        public ActionResult SendResponse<T>(ApiResponse<T> response)
        {
            if (response.StatusCode == StatusCodes.Status204NoContent)
                return new OkObjectResult(null) { StatusCode = response.StatusCode };
            return new OkObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
 