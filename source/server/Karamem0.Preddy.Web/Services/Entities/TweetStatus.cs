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

namespace Karamem0.Preddy.Services.Entities
{

    public class TweetStatus
    {

        public TweetStatus()
        {
        }

        public DateTime? MinDate { get; set; }

        public DateTime? MaxDate { get; set; }

        public IReadOnlyList<TweetStatusItem>? Items { get; set; }

    }

}
