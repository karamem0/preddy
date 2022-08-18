//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Models;
using Karamem0.Preddy.Models.Database;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Services
{

    public class AzureMLService
    {

        private readonly AzureMLContext context;

        public AzureMLService(AzureMLContext context)
        {
            this.context = context;
        }

        public async Task RunAsync()
        {
            await this.context
                .RunAsync()
                .ConfigureAwait(false);
        }

    }

}
