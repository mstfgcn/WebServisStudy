using Infrastructure.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.DataAccess.Implementations.EF.Contexts;
using WS.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Repositories
{
    public class AdminPanelUserRepository : BaseRepository<AdminPanelUser, NorthwndContext>, IAdminPanelUserRepository

    {
        public async Task<AdminPanelUser> GetByUserNameAndPassword(string userName, string password, params string[] includeList)
        {
            return await GetAsync(user => user.UserName == userName && user.Password==password && user.IsActive==true, includeList  );
        }
    }
}
