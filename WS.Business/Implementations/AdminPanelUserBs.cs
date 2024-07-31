using AutoMapper;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccess.Interfaces;
using WS.Model.Dtos.AdminPanelUser;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class AdminPanelUserBs : IAdminPanelUserBs
    {
        private readonly IAdminPanelUserRepository _repo;
        private readonly IMapper _mapper;
        public AdminPanelUserBs(IAdminPanelUserRepository repo,IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ApiResponse<AdminPanelUserDto>> GetUserNameAndPasswordAsync(string userName, string password, params string[] includeList)
        {
            //kullanıcı adı ve şifre if ile kontrol yapabiliriz.

            var respose = await _repo.GetByUserNameAndPassword(userName, password, includeList);

            if (respose == null)
            {

                throw new BadRequestException("Kullanıcı adı yada şifre hatalı");
                
            }
            var returnedDto=_mapper.Map<AdminPanelUserDto>(respose);
            return ApiResponse<AdminPanelUserDto>.Success(StatusCodes.Status200OK, returnedDto);
                
                
        }
    }
}
