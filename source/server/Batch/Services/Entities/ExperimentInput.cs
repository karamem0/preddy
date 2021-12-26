//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Batch.Services.Entities
{

    public class ExperimentInput
    {

        public ExperimentInput()
        {
        }

        [Index(0)]
        [Format("s")]
        [Name("date")]
        public DateTime Date { get; set; }

        [Index(1)]
        [Name("year")]
        public int Year { get; set; }

        [Index(2)]
        [Name("month")]
        public int Month { get; set; }

        [Index(3)]
        [Name("day")]
        public int Day { get; set; }

        [Index(4)]
        [Name("count")]
        public int Count { get; set; }

    }

}
