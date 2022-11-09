//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Models.Twitter.Search
{

    public class TweetMedia
    {

        public TweetMedia()
        {
        }

        [JsonPropertyName("media_key")]
        public string? MediaKey { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

    }

}
