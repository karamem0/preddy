﻿using Karemem0.Preddy.Extensions;
using Karemem0.Preddy.Models;
using Karemem0.Preddy.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karemem0.Preddy.Services {

    /// <summary>
    /// ツイートのログを操作するサービスを表します。
    /// </summary>
    public class TweetLogService : IDisposable {

        /// <summary>
        /// データベース コンテキストを表します。
        /// </summary>
        private DefaultConnectionContext dbContext;

        /// <summary>
        /// <see cref="Karemem0.Preddy.Services.TweetLogService"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        public TweetLogService() {
            this.dbContext = new DefaultConnectionContext();
        }

        /// <summary>
        /// 指定した日付のツイートを検索します。
        /// </summary>
        /// <param name="date">日付を示す <see cref="System.DateTime"/>。</param>
        /// <returns><see cref="Karemem0.Preddy.ViewModels.TweetLogViewModel"/> のコレクション。</returns>
        public IEnumerable<TweetLogViewModel> Search(DateTime date) {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            var cultureInfo = CultureInfo.GetCultureInfo("ja-JP");
            var minDate = date.ToUniversalTime(timeZone);
            var maxDate = date.AddDays(1).ToUniversalTime(timeZone);
            return this.dbContext.TweetLogs
                .Where(item => item.TweetedAt >= minDate)
                .Where(item => item.TweetedAt < maxDate)
                .OrderBy(item => item.TweetedAt)
                .ToList()
                .Select(item => new TweetLogViewModel() {
                    StatusId = item.StatusId,
                    UserId = item.UserId,
                    UserName = item.UserName,
                    ScreenName = "@" + item.ScreenName,
                    Text = item.Text.Replace("\n", "<br>"),
                    ProfileImageUrl = item.ProfileImageUrl,
                    TweetedAt = item.TweetedAt.ToLocalTime(timeZone).ToString(cultureInfo.DateTimeFormat),
                    StatusUrl = string.Format("https://twitter.com/{0}/status/{1}", item.ScreenName, item.StatusId),
                    UserUrl = string.Format("https://twitter.com/{0}", item.ScreenName),
                    MediaUrl = item.MediaUrl,
                });
        }

        /// <summary>
        /// 現在のインスタンスで使用されているリソースを解放します。
        /// </summary>
        public void Dispose() {
            if (this.dbContext != null) {
                this.dbContext.Dispose();
            }
        }

    }

}