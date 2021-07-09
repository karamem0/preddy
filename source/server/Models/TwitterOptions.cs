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

namespace Karamem0.Preddy.Models
{

    public class TwitterOptions
    {

        public TwitterOptions()
        {
        }

        public string? ConsumerKey { get; set; }

        public string? ConsumerSecret { get; set; }

        public string? SearchQuery { get; set; }

        public int? SearchMaxResults { get; set; }

    }

}
