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

    public class TweetSearch
    {

        public TweetSearch()
        {
        }

        [JsonPropertyName("includes")]
        public TweetIncludes? Includes { get; set; }

        [JsonPropertyName("meta")]
        public TweetSearchMetadata? Metadata { get; set; }

        [JsonPropertyName("data")]
        public IReadOnlyList<TweetStatus>? Statuses { get; set; }

    }


}
