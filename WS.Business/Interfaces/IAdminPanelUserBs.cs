using Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Model.Dtos.AdminPanelUser;
using WS.Model.Dtos.Category;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IAdminPanelUserBs
    {
        Task<ApiResponse<AdminPanelUserDto>> GetUserNameAndPasswordAsync(string userName, string password,params string[] includeList);
    }
}
