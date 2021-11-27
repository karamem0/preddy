//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

using Karamem0.Preddy.Batch.Services;
using Karamem0.Preddy.Models;
using Karamem0.Preddy.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
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
            _ = services.AddMicrosoftIdentityWebApiAuthentication(this.Configuration, "AzureAD");
            _ = services.AddDbContext(this.Configuration);
            _ = services.AddAzureMLContext(this.Configuration);
            _ = services.AddBlobStorageContext(this.Configuration);
            _ = services.AddTwitterContext(this.Configuration);
            _ = services.AddBatchServices();
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
            _ = app.UseRouting();
            _ = app.UseAuthentication();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(endpoints => _ = endpoints.MapControllers());
        }

    }

}
