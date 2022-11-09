//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

var builder = new HostBuilder();

_ = builder.ConfigureFunctionsWorkerDefaults();
_ = builder.ConfigureAppConfiguration((context, builder) =>
{
    _ = builder.AddJsonFile("appsettings.json", true, true);
    _ = builder.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT")}.json", true, true);
    _ = builder.AddUserSecrets(typeof(Program).Assembly, true);
    _ = builder.AddEnvironmentVariables();
});
_ = builder.ConfigureServices((context, services) =>
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
});

var app = builder.Build();

app.Run();
