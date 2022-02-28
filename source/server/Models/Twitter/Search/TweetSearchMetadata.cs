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

    public class TweetSearchMetadata
    {

        public TweetSearchMetadata()
        {
        }

        [JsonPropertyName("newest_id")]
        public string? NewestId { get; set; }

        [JsonPropertyName("next_token")]
        public string? NextToken { get; set; }

        [JsonPropertyName("oldest_id")]
        public string? OldestId { get; set; }

        [JsonPropertyName("result_count")]
        public int ResultCount { get; set; }

    }


}
