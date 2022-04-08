using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CursoDotNet.CrossCutting.Contracts.Services;
using CursoDotNet.CrossCutting.Services;
using CursoDotNet.Application.Services;
using CursoDotNet.DataAccess.Contracts.Repositories;
using CursoDotNet.DataAccess.Repositories;
using CursoDotNet.DataAccess.Contracts;
using CursoDotNet.DataAccess;
using CursoDotNet.Application.Contracts.Services;
using CursoDotNet.Application.BusinessModels.Models;
using CursoDotNet.DataAccess.Contracts.Dtos;

namespace CursoDotNet.CrossCutting.Configuration
{
    public static class IoC 
    {

        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            AddRegistration(services);
            AddRepositories(services);
            AddServices(services);

            return services;
        }

        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {



            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {            
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICacheService, CacheService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {           
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }


    }
}