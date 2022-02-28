//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Models
{

    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<TweetForecast> TweetForecasts => this.Set<TweetForecast>();

        public DbSet<TweetStatus> TweetStatuses => this.Set<TweetStatus>();

        public DbSet<TweetActual> TweetActuals => this.Set<TweetActual>();

    }

}
