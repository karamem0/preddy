//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Models;
using Karamem0.Preddy.Models.Database;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Batch.Services
{

    public class TwitterService
    {

        private readonly TwitterContext context;

        private readonly TwitterOptions options;

        public TwitterService(TwitterContext context, IOptions<TwitterOptions> options)
        {
            this.context = context;
            this.options = options.Value;
        }

        public async IAsyncEnumerable<TweetStatus> SearchAsync(ulong? sinceId)
        {
            if (this.options.SearchQuery is null)
            {
                throw new InvalidOperationException();
            }
            var nextToken = default(string);
            while (true)
            {
                var search = await this.context.SearchAsync(
                    this.options.SearchQuery,
                    sinceId,
                    this.options.SearchMaxResults,
                    nextToken);
                if (search?.Statuses is not null)
                {
                    foreach (var status in search.Statuses
                        .Select(status => new
                        {
                            Status = status,
                            User = search?.Includes?.Users?
                                .Where(user => user.Id == status.AuthorId)
                                .FirstOrDefault(),
                            Media = search?.Includes?.Media?
                                .Where(media => status.Attachments?.MediaKeys?.Contains(media.MediaKey) == true)
                                .FirstOrDefault()
                        }))
                    {
                        yield return new TweetStatus()
                        {
                            StatusId = ulong.Parse(status.Status!.Id!),
                            UserId = ulong.Parse(status.Status!.AuthorId!),
                            UserName = status.User?.Name,
                            ScreenName = status.User?.UserName,
                            ProfileImageUrl = status.User?.ProfileImageUrl,
                            MediaUrl = status.Media?.Url,
                            Text = status.Status?.Text,
                            TweetedAt = status.Status?.CreatedAt ?? default
                        };
                    }
                }
                nextToken = search?.Metadata?.NextToken;
                if (nextToken is null)
                {
                    break;
                }
            }
        }

    }

}
