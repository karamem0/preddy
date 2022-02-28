//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Models;
using Karamem0.Preddy.Services.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Services
{

    public class TweetStatusService
    {

        private readonly DatabaseContext context;

        public TweetStatusService(DatabaseContext context)
        {
            this.context = context;
        }

        public async ValueTask<TweetStatus> FindAsync(DateTime minDate, DateTime maxDate)
        {
            var statuses = await this.context.TweetStatuses
                .Where(item => item.TweetedAt >= minDate)
                .Where(item => item.TweetedAt < maxDate)
                .OrderBy(item => item.TweetedAt)
                .ToListAsync();
            return new TweetStatus()
            {
                Items = statuses
                    .Select(item => new TweetStatusItem()
                    {
                        StatusId = item.StatusId,
                        UserId = item.UserId,
                        UserName = item.UserName,
                        ScreenName = $"@{item.ScreenName}",
                        Text = item.Text?.Replace("\n", "<br>"),
                        ProfileImageUrl = item.ProfileImageUrl,
                        TweetedAt = DateTime.SpecifyKind(item.TweetedAt, DateTimeKind.Utc),
                        StatusUrl = $"https://twitter.com/{item.ScreenName}/status/{item.StatusId}",
                        UserUrl = $"https://twitter.com/{item.ScreenName}",
                        MediaUrl = item.MediaUrl,
                    })
                    .ToList()
            };
        }

    }

}
