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

    public class TweetStatus
    {

        public TweetStatus()
        {
        }

        public IReadOnlyList<TweetStatusItem>? Items { get; set; }

    }

}
