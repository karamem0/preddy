//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Azure.Storage.Blobs;
using Karamem0.Preddy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy
{

    public static class ConfigureServices
    {

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<DatabaseContext>(
                options => _ = options.UseSqlServer(
                    configuration.GetConnectionString("SqlDatabaseConnection")));
        }

        public static IServiceCollection AddBlobStorageContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddTransient(options => new BlobContainerClient(
                    configuration.GetConnectionString("BlobStorageConnection"),
                    "azureml-experimentstore"))
                .AddTransient<BlobStorageContext>();
        }

        public static IServiceCollection AddTwitterContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<TwitterOptions>(configuration.GetSection("Twitter"))
                .AddTransient<TwitterAuthenticationProvider>()
                .AddTransient<TwitterContext>();
        }

        public static IServiceCollection AddAzureMLContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddTransient(services => ConfidentialClientApplicationBuilder
                    .CreateWithApplicationOptions(configuration
                        .GetSection("AzureAD")
                        .Get<ConfidentialClientApplicationOptions>())
                    .Build())
                .AddTransient(_ => configuration.GetSection("AzureML").Get<AzureMLOptions>())
                .AddTransient<AzureMLContext>();
        }

    }

}
