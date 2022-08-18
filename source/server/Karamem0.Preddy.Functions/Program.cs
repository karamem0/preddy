//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.Preddy
{

    public static class Program
    {

        public static void Main()
        {
            new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    _ = builder.AddJsonFile("appsettings.json", true, true);
                    _ = builder.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT")}.json", true, true);
                    _ = builder.AddUserSecrets(typeof(Program).Assembly, true);
                    _ = builder.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    Console.Write(context.Configuration.GetConnectionString("SqlDatabaseConnection"));
                    _ = services.AddApplicationInsightsTelemetryWorkerService();
                    _ = services.AddLogging(builder => _ = builder.AddApplicationInsights());
                    _ = services.AddHttpClient();
                    _ = services.AddDbContext(context.Configuration);
                    _ = services.AddBlobStorageContext(context.Configuration);
                    _ = services.AddTwitterContext(context.Configuration);
                    _ = services.AddAzureMLContext(context.Configuration);
                    _ = services.AddServices();
                })
                .Build()
                .Run();
        }

    }

}
