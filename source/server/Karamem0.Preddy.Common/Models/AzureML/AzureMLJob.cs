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

    public class AzureMLJob
    {

        public AzureMLJob()
        {
        }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("properties")]
        public IReadOnlyDictionary<string, object>? Properties { get; set; }

        [JsonPropertyName("systemData")]
        public AzureMLSystemData? SystemData { get; set; }

    }

}
