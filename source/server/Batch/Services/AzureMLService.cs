//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

using Karamem0.Preddy.Models;
using Karamem0.Preddy.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Batch.Services
{

    public class AzureMLService
    {

        private readonly AzureMLContext context;

        public AzureMLService(AzureMLContext context)
        {
            this.context = context;
        }

        public async IAsyncEnumerable<TweetForecast> SearchAsync()
        {
            var forecasts = await this.context.SearchAsync();
            foreach (var forecast in forecasts)
            {
                yield return new TweetForecast()
                {
                    Date = forecast.Key,
                    Year = forecast.Key.Year,
                    Month = forecast.Key.Month,
                    Day = forecast.Key.Day,
                    Count = forecast.Value
                };
            }
        }

    }

}
