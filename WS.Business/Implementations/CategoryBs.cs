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
using WS.Model.Dtos.Category;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class CategoryBs : ICategoryBs
    {
        private readonly ICategoryRepository  _repo;
        private readonly IMapper _mapper;



        public CategoryBs(ICategoryRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

       

        public async Task<ApiResponse<List<CategoryGetDto>>> GetAllCategoryAsync(params string[] includeList)
        {
            var dtoList =await _repo.GetAllAsync(includeList:includeList);
            if (dtoList != null)
            {
                var returnedList = _mapper.Map<List<CategoryGetDto>>(includeList);
                return ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, returnedList);
            }
            throw new NotFoundException("Kaynak Bulunamadı");
        }

        public async Task<ApiResponse<CategoryGetDto>> GetCategoryAsync(int categoryId, params string[] includeList)
        {
            var dtoList = await _repo.GetByCategoryId(categoryId, includeList);
            if (dtoList != null)
            {
                var response = _mapper.Map<CategoryGetDto>(includeList);
                return ApiResponse<CategoryGetDto>.Success(StatusCodes.Status200OK, response);
            }    
            
            throw new NotFoundException("Kaynak Bulunamadı.");
        }

        public async Task<ApiResponse<Category>> InsertAsync(CategoryPostDto category)
        {
            if (category.CategoryName.Length <= 2)
                throw new  BadRequestException("Category adı 2 veya daha az karakterden oluşamaz.");
            if (category.Description.Length <= 10)
                throw new BadRequestException("Catgory açıklaması en az 10 karakter olmalıdır.");

            var entity = _mapper.Map<Category>(category);
            var insertEntity=await _repo.InsertAsync(entity);
            return ApiResponse<Category>.Success(StatusCodes.Status201Created,insertEntity);


        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto category)
        {
            if(category.CategoryName.Length <= 2)
                throw new BadRequestException("Category adı 2 veya daha az karakterden oluşamaz.");
            if (category.Description.Length <= 10)
                throw new BadRequestException("Catgory açıklaması en az 10 karakter olmalıdır.");
            var entity =_mapper.Map<Category>(category);
            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);


        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new NotFoundException("Id pozitif bir değer olmalıdır");
            var category = await _repo.GetByCategoryId(categoryId);
            await _repo.DeleteAsync(category);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
