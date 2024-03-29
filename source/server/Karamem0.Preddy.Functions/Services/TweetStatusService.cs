//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Models;
using Karamem0.Preddy.Models.Database;
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

        public async Task<TweetStatus> GetMaxAsync()
        {
            return await this.context.TweetStatuses
                .Where(item => item.StatusId == this.context.TweetStatuses.Max(item => item.StatusId))
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public async Task AddOrUpdateAsync(TweetStatus newValue)
        {
            var oldValue = this.context.TweetStatuses.SingleOrDefault(item => item.StatusId == newValue.StatusId);
            if (oldValue is null)
            {
                newValue.CreatedAt = DateTime.UtcNow;
                newValue.UpdatedAt = DateTime.UtcNow;
                _ = this.context.TweetStatuses.Add(newValue);
            }
            else
            {
                oldValue.UserId = newValue.UserId;
                oldValue.UserName = newValue.UserName;
                oldValue.ScreenName = newValue.ScreenName;
                oldValue.ProfileImageUrl = newValue.ProfileImageUrl;
                oldValue.Text = newValue.Text;
                oldValue.TweetedAt = newValue.TweetedAt;
                oldValue.UpdatedAt = DateTime.UtcNow;
            }
            _ = await this.context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }

    }

}
