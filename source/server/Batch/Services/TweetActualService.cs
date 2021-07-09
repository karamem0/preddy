//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

using Karamem0.Preddy.Models;
using Karamem0.Preddy.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Batch.Services
{

    public class TweetActualService
    {

        private readonly DatabaseContext context;

        public TweetActualService(DatabaseContext context)
        {
            this.context = context;
        }

        public async IAsyncEnumerable<TweetActual> SearchAsync()
        {
            var minDate = DateTime.Now.Date.AddDays(-30);
            var maxDate = DateTime.Now.Date;
            for (var date = minDate; date <= maxDate; date = date.AddDays(1))
            {
                var minTweetedAt = date.ToUniversalTime();
                var maxTweetedAt = date.AddDays(1).ToUniversalTime();
                var tweetCount = await this.context.TweetStatuses
                    .Where(item => item.TweetedAt >= minTweetedAt)
                    .Where(item => item.TweetedAt < maxTweetedAt)
                    .CountAsync();
                yield return new TweetActual()
                {
                    Date = date,
                    Year = date.Year,
                    Month = date.Month,
                    Day = date.Day,
                    Count = tweetCount,
                };
            }
        }

        public async Task AddOrUpdateAsync(TweetActual newValue)
        {
            var oldValue = this.context.TweetActuals.SingleOrDefault(item => item.Date == newValue.Date);
            if (oldValue is null)
            {
                newValue.CreatedAt = DateTime.UtcNow;
                newValue.UpdatedAt = DateTime.UtcNow;
                this.context.TweetActuals.Add(newValue);
            }
            else
            {
                oldValue.Year = newValue.Year;
                oldValue.Month = newValue.Month;
                oldValue.Day = newValue.Day;
                oldValue.Count = newValue.Count;
                oldValue.UpdatedAt = DateTime.UtcNow;
            }
            await this.context.SaveChangesAsync();
        }

    }

}
