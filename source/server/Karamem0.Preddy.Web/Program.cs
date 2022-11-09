//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;
_ = services.AddControllers();
_ = services.AddHttpClient();
_ = services.AddCors(options =>
    options.AddDefaultPolicy(builder => _ = builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()));
_ = services.AddApplicationInsightsTelemetry();
_ = services.AddDbContext(configuration);
_ = services.AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    _ = app.UseDeveloperExceptionPage();
    _ = app.UseCors();
}
_ = app.UseHttpsRedirection();
_ = app.UseDefaultFiles();
_ = app.UseStaticFiles();
_ = app.UseRouting();
_ = app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
    _ = endpoints.MapFallbackToFile("/index.html");
});

app.Run();
