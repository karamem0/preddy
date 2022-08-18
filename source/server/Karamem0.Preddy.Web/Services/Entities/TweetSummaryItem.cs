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

    public class TweetSummaryItem
    {

        public TweetSummaryItem()
        {
        }

        public DateTime? Date { get; set; }

        public double? Forecast { get; set; }

        public int? Actual { get; set; }

    }

}
