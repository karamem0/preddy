//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Functions
{

    public class TweetForecastFunction
    {

        private readonly ILogger logger;

        private readonly TweetForecastService tweetForecastService;

        public TweetForecastFunction(ILoggerFactory loggerFactory, TweetForecastService tweetForecastService)
        {
            this.logger = loggerFactory.CreateLogger<TweetForecastFunction>();
            this.tweetForecastService = tweetForecastService;
        }

#pragma warning disable IDE0060
        [Function("TweetForecast")]
        public async Task Run([BlobTrigger($"{Constants.BlobName}/{Constants.ExperimentOutputFileName}", Connection = "ConnectionStrings:BlobStorageConnection")] string blob, string name)
        {
            var forecasts = this.tweetForecastService.ImportAsync();
            await foreach (var forecast in forecasts)
            {
                await this.tweetForecastService.AddOrUpdateAsync(forecast);
            }
        }
#pragma warning restore IDE0060

    }

}
