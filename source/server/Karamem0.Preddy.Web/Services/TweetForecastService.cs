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

    public class TweetForecastService
    {

        private readonly DatabaseContext context;

        public TweetForecastService(DatabaseContext context)
        {
            this.context = context;
        }

        public async ValueTask<TweetForecast> FindAsync(DateTime minDate, DateTime maxDate)
        {
            var ranks = await this.context.TweetForecasts
                .Where(item => item.Date >= minDate)
                .Where(item => item.Date <= maxDate)
                .OrderByDescending(item => item.Count)
                .Take(3)
                .ToListAsync()
                .ConfigureAwait(false);
            return new TweetForecast()
            {
                MinDate = minDate,
                MaxDate = maxDate,
                Items = ranks
                    .Select(item => new TweetForecastItem()
                    {
                        Date = item.Date,
                        Count = item.Count,
                    })
                    .OrderBy(item => item.Date)
                    .ToList()
            };
        }

    }

}
