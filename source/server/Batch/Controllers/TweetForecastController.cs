//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Batch.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Batch.Controllers
{

    [ApiController()]
    [Authorize()]
    [Route("batch/[controller]")]
    public class TweetForecastController : ControllerBase
    {

        private readonly ILogger<TweetForecastController> logger;

        private readonly TweetForecastService tweetForecastService;

        public TweetForecastController(
            ILogger<TweetForecastController> logger,
            TweetForecastService tweetForecastService)
        {
            this.logger = logger;
            this.tweetForecastService = tweetForecastService;
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync()
        {
            var forecasts = this.tweetForecastService.ImportAsync();
            await foreach (var forecast in forecasts)
            {
                await this.tweetForecastService.AddOrUpdateAsync(forecast);
            }
            return this.Ok();
        }

    }

}
