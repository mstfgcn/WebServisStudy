using AutoMapper;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccess.Interfaces;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
  public class ProductBs : IProductBs
  {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
       

        public ProductBs(IProductRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        } 
 



    public async Task<ApiResponse<ProductGetDto>> GetProductByIdAsync(int productId, params string[] includeList)
        {
            if (productId <= 0)
                throw new BadRequestException("ProductId 0'dan küçük olamaz");


            var products=await _repo.GetByIdAsync(productId, includeList);
            if(products == null)
                throw new NotFoundException("Ürün bulunamadı");


            var response = _mapper.Map<ProductGetDto>(products);

            return ApiResponse<ProductGetDto>.Success(StatusCodes.Status200OK, response);
        }

    public async Task<ApiResponse<List<ProductGetDto>>> GetProductsAsync(params string[] includeList)
        {
            var product =await _repo.GetAllAsync(includeList:includeList);
            if (product.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(product);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK,returnList);
            }          
            throw new NotFoundException("Ürün bulunamadı");
        }

    public async Task<ApiResponse<List<ProductGetDto>>> GetProductsByCategoryAsync(int categoryId, params string[] includeList)
    {
        
      if(categoryId <= 0)
         throw new BadRequestException("CategoryID 0 dan küçük olamaz");

      var products =await _repo.GetByCategoryAsync(categoryId , includeList);
            if(products.Count > 0)
            {
                var response = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, response);
            }       
            throw new NotFoundException("Ürün Bulunamadı.");
     }

    public async Task<ApiResponse<List<ProductGetDto>>> GetProductsByPriceAsync(decimal min, decimal max, params string[] includeList)
    {
      if (min <=0 || max <=0)
                throw new BadRequestException("Değerler pozitif olmalıdır.");
            if (min > max)
                throw new BadRequestException("Min değer max büyük olamaz.");

     var products =await _repo.GetByPriceAsync(min,max, includeList);
            if (products.Count > 0) 
            { 
                var response = _mapper.Map<List<ProductGetDto>>(products);
            return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, response);
            }
            throw new NotFoundException("Ürün bulunamadı");
    }

    public async Task<ApiResponse<List<ProductGetDto>>> GetProductsByStockAsync(short min, short max, params string[] includeList)
    {
            if (min <= 0 || max <= 0)
                throw new BadRequestException("Değerler pozitif olmalıdır.");
            if (min > max)
                throw new BadRequestException("Min değer max büyük olamaz.");

            var products=await _repo.GetByStockAsync(min, max, includeList);
            if (products.Count > 0)
            {
                var response = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, response);
            }

            throw new NotFoundException("Ürün bulunamadı");
        }

    public async Task<ApiResponse<Product>> InsertAsync(ProductPostDto product)
        {
            if(product.ProductName.Length <2)
                throw new BadRequestException("Ürün adı 2 karakterden küçük olamaz.");
            if (product.UnitsInStock < 1)
                throw new BadRequestException("Stok adeti 1 den küçük olamaz");
            //vs.

            var entity= _mapper.Map<Product>(product);
            var insertedProduct =await _repo.InsertAsync(entity);
            return ApiResponse<Product>.Success(StatusCodes.Status201Created,insertedProduct);
            
        }

    public async Task<ApiResponse<NoData>> UpdateAsync(ProductPutDto product)
        {
            if (product.ProductId <= 0)
                //middlewareden önce
                //return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, "Id pozitif bir değer olmalıdır");
                throw new BadRequestException("Id pozitif bir değer olmalıdır");
            if (product.ProductName.Length < 2)
                throw new BadRequestException("Ürün adı 2 karakterden küçük olamaz.");
            if (product.UnitsInStock < 0)
                throw new BadRequestException("Stok adeti 0 den küçük olamaz");

            var entity = _mapper.Map<Product>(product);
            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new NotFoundException("Id pozitif bir değer olmalıdır");
            var product =await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(product);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    
  }
}
