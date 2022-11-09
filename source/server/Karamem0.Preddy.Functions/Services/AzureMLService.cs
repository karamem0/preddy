//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Models;
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

        public async Task RunPipelineAsync()
        {
            await this.context
                .RunPipelineAsync()
                .ConfigureAwait(false);
        }

        public async Task DeleteJobsAsync()
        {
            var timestamp = DateTime.UtcNow.AddDays(-7);
            await foreach (var item in this.context.GetJobsAsync())
            {
                if (item.SystemData == null || item.SystemData.CreatedAt <= timestamp)
                {
                    if (item.Name != null)
                    {
                        await this.context.DeleteJobAsync(item.Name);
                    }
                }
            }
        }

    }

}
