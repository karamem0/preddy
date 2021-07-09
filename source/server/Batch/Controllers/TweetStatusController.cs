//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
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
    public class TweetStatusController : ControllerBase
    {

        private readonly ILogger<TweetStatusController> logger;

        private readonly TweetStatusService tweetStatusService;

        private readonly TwitterService twitterService;

        public TweetStatusController(
            ILogger<TweetStatusController> logger,
            TweetStatusService tweetStatusService,
            TwitterService twitterService)
        {
            this.logger = logger;
            this.tweetStatusService = tweetStatusService;
            this.twitterService = twitterService;
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync()
        {
            var max = await tweetStatusService.GetMaxAsync();
            var statuses = twitterService.SearchAsync(max.StatusId);
            await foreach (var status in statuses)
            {
                await tweetStatusService.AddOrUpdateAsync(status);
            }
            return this.Ok();
        }

    }

}
