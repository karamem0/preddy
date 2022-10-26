//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Logging;
using Karamem0.Preddy.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Functions
{

    public class TweetActualFunction
    {

        private readonly ILogger logger;

        private readonly TweetActualService tweetActualService;

        private readonly AzureMLService azuremlService;

        public TweetActualFunction(
            ILoggerFactory loggerFactory,
            TweetActualService tweetActualService,
            AzureMLService azuremlService)
        {
            this.logger = loggerFactory.CreateLogger<TweetActualFunction>();
            this.tweetActualService = tweetActualService;
            this.azuremlService = azuremlService;
        }

#pragma warning disable IDE0060
        [Function("TweetActual")]
        public async Task Run([TimerTrigger("0 0 * * * *")] object timerInfo)
        {
            try
            {
                var actuals = this.tweetActualService.SearchAsync();
                await foreach (var actual in actuals)
                {
                    await this.tweetActualService.AddOrUpdateAsync(actual);
                }
                await this.tweetActualService.ExportAsync();
                await this.azuremlService.RunPipelineAsync();
                await this.azuremlService.DeleteJobsAsync();
            }
            catch (Exception ex)
            {
                this.logger.UnhandledError(ex);
            }
        }
#pragma warning restore IDE0060

    }

}
