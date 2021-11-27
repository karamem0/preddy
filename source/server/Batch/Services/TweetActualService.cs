//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

using Karamem0.Preddy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database = Karamem0.Preddy.Models.Database;
using Entities = Karamem0.Preddy.Batch.Services.Entities;

namespace Karamem0.Preddy.Batch.Services
{

    public class TweetActualService
    {

        private readonly DatabaseContext databaseContext;

        private readonly BlobStorageContext blobStorageContext;

        public TweetActualService(DatabaseContext databaseContext, BlobStorageContext blobStorageContext)
        {
            this.databaseContext = databaseContext;
            this.blobStorageContext = blobStorageContext;
        }

        public async IAsyncEnumerable<Database.TweetActual> SearchAsync()
        {
            var minDate = DateTime.Now.Date.AddDays(-30);
            var maxDate = DateTime.Now.Date;
            for (var date = minDate; date <= maxDate; date = date.AddDays(1))
            {
                var minTweetedAt = date.ToUniversalTime();
                var maxTweetedAt = date.AddDays(1).ToUniversalTime();
                var tweetCount = await this.databaseContext.TweetStatuses
                    .Where(item => item.TweetedAt >= minTweetedAt)
                    .Where(item => item.TweetedAt < maxTweetedAt)
                    .CountAsync();
                yield return new Database.TweetActual()
                {
                    Date = date,
                    Year = date.Year,
                    Month = date.Month,
                    Day = date.Day,
                    Count = tweetCount,
                };
            }
        }

        public async Task AddOrUpdateAsync(Database.TweetActual newValue)
        {
            var oldValue = this.databaseContext.TweetActuals
                .SingleOrDefault(item => item.Date == newValue.Date);
            if (oldValue is null)
            {
                newValue.CreatedAt = DateTime.UtcNow;
                newValue.UpdatedAt = DateTime.UtcNow;
                _ = this.databaseContext.TweetActuals.Add(newValue);
            }
            else
            {
                oldValue.Year = newValue.Year;
                oldValue.Month = newValue.Month;
                oldValue.Day = newValue.Day;
                oldValue.Count = newValue.Count;
                oldValue.UpdatedAt = DateTime.UtcNow;
            }
            _ = await this.databaseContext.SaveChangesAsync();
        }

        public async Task ExportAsync()
        {
            await this.blobStorageContext.UploadAsync(
                "tweetactual.csv",
                await this.databaseContext.TweetActuals
                .OrderBy(item => item.Date)
                .Select(item => new Entities.TweetActual()
                {
                    Date = item.Date,
                    Year = item.Year,
                    Month = item.Month,
                    Day = item.Day,
                    Count = item.Count,
                })
                .ToArrayAsync()
            );
        }

    }

}
