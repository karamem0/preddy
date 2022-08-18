//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy
{

    public static class ConfigureServices
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<TweetForecastService>()
                .AddScoped<TweetStatusService>()
                .AddScoped<TweetSummaryService>();
        }

    }

}
