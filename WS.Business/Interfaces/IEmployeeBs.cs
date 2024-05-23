using Infrastructure.Utilities;
using WS.Model.Dtos.Employee;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
  public interface IEmployeeBs
  {

        Task<ApiResponse<List<EmployeeGetDto>>> GetAllEmployee(params string[] includeList);

    }
}
