//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Batch.Services
{

    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddBatchServices(this IServiceCollection services)
        {
            return services
                .AddTransient<AzureMLService>()
                .AddTransient<TwitterService>()
                .AddTransient<TweetActualService>()
                .AddTransient<TweetForecastService>()
                .AddTransient<TweetStatusService>();
        }

    }

}
