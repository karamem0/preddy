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

    public class TweetStatus
    {

        public TweetStatus()
        {
        }

        [JsonPropertyName("attachments")]
        public TweetAttachment? Attachments { get; set; }

        [JsonPropertyName("author_id")]
        public string? AuthorId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

    }

}
