//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Models;
using Karamem0.Preddy.Models.Database;
using Karamem0.Preddy.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Services
{

    public class TweetForecastService
    {

        private readonly DatabaseContext databaseContext;

        private readonly BlobStorageContext blobStorageContext;

        public TweetForecastService(DatabaseContext databaseContext, BlobStorageContext blobStorageContext)
        {
            this.databaseContext = databaseContext;
            this.blobStorageContext = blobStorageContext;
        }

        public async Task AddOrUpdateAsync(TweetForecast newValue)
        {
            var oldValue = this.databaseContext.TweetForecasts.SingleOrDefault(item => item.Date == newValue.Date);
            if (oldValue is null)
            {
                newValue.CreatedAt = DateTime.UtcNow;
                newValue.UpdatedAt = DateTime.UtcNow;
                _ = this.databaseContext.TweetForecasts.Add(newValue);
            }
            else
            {
                oldValue.Year = newValue.Year;
                oldValue.Month = newValue.Month;
                oldValue.Day = newValue.Day;
                oldValue.Count = newValue.Count;
                oldValue.UpdatedAt = DateTime.UtcNow;
            }
            _ = await this.databaseContext
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async IAsyncEnumerable<TweetForecast> ImportAsync()
        {
            var values = await this.blobStorageContext
                .DownloadAsync<ExperimentOutput>(Constants.ExperimentOutputFileName)
                .ConfigureAwait(false);
            foreach (var value in values)
            {
                yield return new TweetForecast()
                {
                    Date = value.Date,
                    Year = value.Date.Year,
                    Month = value.Date.Month,
                    Day = value.Date.Day,
                    Count = value.Mean
                };
            }
        }

    }

}
