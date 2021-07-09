//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Services.Entities
{

    public class TweetStatusItem
    {

        public TweetStatusItem()
        {
        }

        public ulong? StatusId { get; set; }

        public ulong? UserId { get; set; }

        public string? UserName { get; set; }

        public string? ScreenName { get; set; }

        public string? Text { get; set; }

        public DateTime? TweetedAt { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string? StatusUrl { get; set; }

        public string? UserUrl { get; set; }

        public string? MediaUrl { get; set; }

    }

}