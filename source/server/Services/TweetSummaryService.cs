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

    public class TweetSummaryService
    {

        private readonly DatabaseContext context;

        public TweetSummaryService(DatabaseContext context)
        {
            this.context = context;
        }

        public async ValueTask<TweetSummary> FindAsync(DateTime minDate, DateTime maxDate)
        {
            var forecasts = await this.context.TweetForecasts
                .Where(item => item.Date >= minDate)
                .Where(item => item.Date <= maxDate)
                .OrderBy(item => item.Date)
                .ToListAsync();
            var actuals = await this.context.TweetActuals
                .Where(item => item.Date >= minDate)
                .Where(item => item.Date <= maxDate)
                .OrderBy(item => item.Date)
                .ToListAsync();
            return new TweetSummary()
            {
                MaxDate = maxDate,
                MinDate = minDate,
                Items = Enumerable.Range(0, maxDate.Subtract(minDate).Days)
                    .Select(x => minDate.AddDays(x).ToLocalTime().Date)
                    .Select(date => new TweetSummaryItem()
                    {
                        Date = date.ToUniversalTime(),
                        Forecast = forecasts
                            .Where(item => item.Date == date)
                            .Select(item => item.Count < 0.0 ? 0.0 : item.Count)
                            .SingleOrDefault(),
                        Actual = actuals
                            .Where(item => item.Date == date)
                            .Select(item => item.Count)
                            .SingleOrDefault(),
                    })
                    .ToList(),
            };
        }

    }

}
