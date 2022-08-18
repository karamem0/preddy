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

    public class TweetStatusFunction
    {

        private readonly ILogger logger;

        private readonly TweetStatusService tweetStatusService;

        private readonly TwitterService twitterService;

        public TweetStatusFunction(
            ILoggerFactory loggerFactory,
            TweetStatusService tweetStatusService,
            TwitterService twitterService)
        {
            this.logger = loggerFactory.CreateLogger<TweetStatusFunction>();
            this.tweetStatusService = tweetStatusService;
            this.twitterService = twitterService;
        }

#pragma warning disable IDE0060
        [Function("TweetStatus")]
        public async Task Run([TimerTrigger("0 0 * * * *")] object timerInfo)
        {
            try
            {
                var max = await this.tweetStatusService.GetMaxAsync();
                var statuses = this.twitterService.SearchAsync(max.StatusId);
                await foreach (var status in statuses)
                {
                    await this.tweetStatusService.AddOrUpdateAsync(status);
                }
            }
            catch (Exception ex)
            {
                this.logger.UnhandledError(ex);
            }
        }
#pragma warning restore IDE0060

    }

}
