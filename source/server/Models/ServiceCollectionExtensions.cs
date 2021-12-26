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
                .AddDbContext<DatabaseContext>(options => _ = options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static IServiceCollection AddBlobStorageContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<BlobStorageOptions>(configuration.GetSection("BlobStorage"))
                .AddTransient<BlobStorageContext>();
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
