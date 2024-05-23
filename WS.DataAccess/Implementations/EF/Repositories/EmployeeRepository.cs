using Infrastructure.DataAccess.EF;
using WS.DataAccess.Implementations.EF.Contexts;
using WS.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Repositories
{
  public class EmployeeRepository : BaseRepository<Employee, NorthwndContext>, IEmployeeRepository
  {
        

    }
}
