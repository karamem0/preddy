﻿using CoreTweet;
using Karemem0.Preddy.Configuration;
using Karemem0.Preddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karemem0.Preddy.Services {

    /// <summary>
    /// Twitter API からツイートを検索するサービスを表します。
    /// </summary>
    public class TwitterService : IDisposable {

        /// <summary>
        /// Twitter トークンを表します。
        /// </summary>
        private Tokens twitterToken;

        /// <summary>
        /// <see cref="Karemem0.Preddy.Services.TwitterService"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        public TwitterService() {
            this.twitterToken = Tokens.Create(
                AppSettings.TwitterConsumerKey,
                AppSettings.TwitterConsumerSecret,
                AppSettings.TwitterAccessToken,
                AppSettings.TwitterAccessTokenSecret
            );
        }

        /// <summary>
        /// 指定したツイート ID を含む過去のツイートを検索します。
        /// </summary>
        /// <param name="maxId">ツイート ID を示す <see cref="System.Int64"/>。</param>
        /// <returns><see cref="Karemem0.Preddy.Models.TweetLog"/> の配列。</returns>
        public TweetLog[] Search(long? maxId = null) {
            var searchQuery = Uri.EscapeUriString(AppSettings.TwitterSearchQuery);
            var searchCount = AppSettings.TwitterSearchCount.GetValueOrDefault();
            var excludeUsers = AppSettings.TwitterExcludeUsers;
            return this.twitterToken.Search.Tweets(
                    q: searchQuery,
                    result_type: "recent",
                    count: searchCount,
                    max_id: maxId.GetValueOrDefault())
                .Where(tweet => tweet.RetweetedStatus == null)
                .Where(tweet => excludeUsers.Contains(tweet.User.ScreenName) != true)
                .Select(tweet => new TweetLog() {
                    Id = Guid.NewGuid(),
                    StatusId = tweet.Id.ToString(),
                    UserId = tweet.User.Id.ToString(),
                    UserName = tweet.User.Name,
                    ScreenName = tweet.User.ScreenName,
                    ProfileImageUrl = tweet.User.ProfileImageUrlHttps,
                    MediaUrl = tweet.Entities.Media?
                        .Where(media => media.Type == "photo")
                        .Select(media => media.MediaUrlHttps)
                        .FirstOrDefault(),
                    Text = tweet.Text,
                    TweetedAt = tweet.CreatedAt.UtcDateTime,
                })
                .OrderByDescending(x => x.TweetedAt)
                .ToArray();
        }

        /// <summary>
        /// 現在のインスタンスで使用されているリソースを解放します。
        /// </summary>
        public void Dispose() { }

    }

}
