using BootcampAres.Application.Contracts.Services;
using BootcampAres.Application.Services;
using BootcampAres.DataAccess;
using BootcampAres.DataAccess.Contracts;
using BootcampAres.DataAccess.Contracts.Repositories;
using BootcampAres.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BootcampAres.CrossCutting.Configuration
{
    public static class IoC
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
