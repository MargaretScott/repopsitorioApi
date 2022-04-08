using CursoDotNet.CrossCutting.Contracts.Services;
using CursoDotNet.CrossCutting.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoDotNet.API.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

    }
}
