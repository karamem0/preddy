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

namespace Karamem0.Preddy.Models.AzureML
{

    public class AzureMLJobCollection
    {

        public AzureMLJobCollection()
        {
        }

        [JsonPropertyName("value")]
        public IReadOnlyCollection<AzureMLJob>? Value { get; set; }

        [JsonPropertyName("nextLink")]
        public string? NextLink { get; set; }

    }

}
