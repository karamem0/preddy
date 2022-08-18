//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Controllers
{

    [ApiController()]
    [Route("api/[controller]")]
    public class TweetStatusController : ControllerBase
    {

        private readonly ILogger<TweetStatusController> logger;

        private readonly TweetStatusService tweetStatusService;

        public TweetStatusController(ILogger<TweetStatusController> logger, TweetStatusService tweetStatusService)
        {
            this.logger = logger;
            this.tweetStatusService = tweetStatusService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync(DateTime minDate, DateTime maxDate)
        {
            if (maxDate <= minDate)
            {
                return this.Problem(
                    detail: "'maxDate' must be greater than 'minDate'.",
                    statusCode: 400
                );
            }
            return this.Ok(await this.tweetStatusService.FindAsync(minDate, maxDate));
        }

    }

}
