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
using System.Threading.Tasks;

namespace Karamem0.Preddy.Models
{

    public class AzureMLOptions
    {

        public AzureMLOptions()
        {
        }

        public string? Location { get; set; }

        public string? ResourceGroup { get; set; }

        public string? PipelineId { get; set; }

        public string? SubscriptionId { get; set; }

        public string? Workspace { get; set; }

    }

}
