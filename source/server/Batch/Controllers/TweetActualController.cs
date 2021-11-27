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
    public class TweetActualController : ControllerBase
    {

        private readonly ILogger<TweetActualController> logger;

        private readonly TweetActualService tweetActualService;

        public TweetActualController(
            ILogger<TweetActualController> logger,
            TweetActualService tweetActualService)
        {
            this.logger = logger;
            this.tweetActualService = tweetActualService;
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync()
        {
            var actuals = this.tweetActualService.SearchAsync();
            await foreach (var actual in actuals)
            {
                await this.tweetActualService.AddOrUpdateAsync(actual);
            }
            await this.tweetActualService.ExportAsync();
            return this.Ok();
        }

    }

}
