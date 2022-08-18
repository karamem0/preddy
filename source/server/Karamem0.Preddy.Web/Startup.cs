//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy
{

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddControllers();
            _ = services.AddHttpClient();
            _ = services.AddCors(options => options.AddDefaultPolicy(builder => _ = builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));
            _ = services.AddApplicationInsightsTelemetry();
            _ = services.AddDbContext(this.Configuration);
            _ = services.AddServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
                _ = app.UseCors();
            }
            _ = app.UseHttpsRedirection();
            _ = app.UseDefaultFiles();
            _ = app.UseStaticFiles();
            _ = app.UseRouting();
            _ = app.UseEndpoints(endpoints => _ = endpoints.MapControllers());
        }

    }

}
