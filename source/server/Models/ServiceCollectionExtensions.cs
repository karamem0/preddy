//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Models
{

    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<DatabaseContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });
        }

        public static IServiceCollection AddAzureMLContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<AzureMLOptions>(configuration.GetSection("AzureML"))
                .AddTransient<AzureMLContext>();
        }

        public static IServiceCollection AddTwitterContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<TwitterOptions>(configuration.GetSection("Twitter"))
                .AddTransient<TwitterAuthenticationProvider>()
                .AddTransient<TwitterContext>();
        }

    }

}
