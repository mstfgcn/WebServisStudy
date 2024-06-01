using Microsoft.Extensions.DependencyInjection;
using WS.Business.Implementations;
using WS.Business.Interfaces;
using WS.DataAccess.Implementations.EF.Repositories;
using WS.DataAccess.Interfaces;

namespace WS.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            // IoC REGISTRATION

            //--------------------------------------------------------------
            services.AddScoped<IProductBs, ProductBs>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IEmployeeBs, EmployeeBs>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<ICategoryBs, CategoryBs>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IOrderBs, OrderBs>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            //--------------------------------------------------------------

            //servis genelinde AutoMapper ı kullanılabilir kılmış oluyoruz, aynı zamanda
            //AutoMapper ın ıhtiyaç duydugu IMapper tipindeki objeyi IoC e register etmiş oluyoruz.
            services.AddAutoMapper(typeof(ProductBs));
        }
    }
}
