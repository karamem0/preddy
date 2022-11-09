//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Models.Database
{

    [Index(nameof(Date), IsUnique = true)]
    [Table(nameof(TweetForecast))]
    public class TweetForecast
    {

        public TweetForecast()
        {
        }

        [Key()]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public double Count { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdatedAt { get; set; }

    }

}
