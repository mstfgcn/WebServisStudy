using AutoMapper;
using Infrastructure.Utilities;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccess.Interfaces;
using WS.Model.Dtos.Employee;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class EmployeeBs : IEmployeeBs
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _repo;

        public EmployeeBs(IMapper mapper,IEmployeeRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetAllEmployee(params string[] includeList)
        {
            var dtoList = await _repo.GetAllAsync(includeList:includeList);

            if (dtoList.Count == 0)
                throw new NotFoundException("kaynak bulunamadı");
            var response =_mapper.Map<List<EmployeeGetDto>>(dtoList);
            return ApiResponse<List<EmployeeGetDto>>.Success(200, response);
        }
    }
}
