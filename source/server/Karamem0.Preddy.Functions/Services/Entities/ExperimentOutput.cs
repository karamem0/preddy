//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Services.Entities
{

    public class ExperimentOutput
    {

        public ExperimentOutput()
        {
        }

        [Index(0)]
        [Format("yyyy/MM/dd")]
        [Name("date")]
        public DateTime Date { get; set; }

        [Index(1)]
        [Name("mean")]
        public double Mean { get; set; }

    }

}
