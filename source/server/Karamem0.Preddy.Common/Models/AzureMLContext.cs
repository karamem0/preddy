//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Models
{

    public class AzureMLContext
    {

        private readonly HttpClient httpClient;

        private readonly IConfidentialClientApplication msalApplication;

        private readonly AzureMLOptions azuremlOptions;

        public AzureMLContext(
            HttpClient httpClient,
            IConfidentialClientApplication msalApplication,
            AzureMLOptions azuremlOptions)
        {
            this.httpClient = httpClient;
            this.msalApplication = msalApplication;
            this.azuremlOptions = azuremlOptions;
        }

        public async Task RunAsync()
        {
            var auth = await this.msalApplication
                .AcquireTokenForClient(new[] { "https://management.azure.com/.default" })
                .ExecuteAsync()
                .ConfigureAwait(false);
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Post,
                $"https://{this.azuremlOptions.Location}.api.azureml.ms" +
                "/pipelines/v1.0" +
                $"/subscriptions/{this.azuremlOptions.SubscriptionId}" +
                $"/resourceGroups/{this.azuremlOptions.ResourceGroup}" +
                "/providers/Microsoft.MachineLearningServices" +
                $"/workspaces/{this.azuremlOptions.Workspace}" +
                $"/PipelineRuns/PipelineSubmit/{this.azuremlOptions.PipelineId}"
            );
            httpRequestMessage.Content = new StringContent("{}", Encoding.UTF8, "application/json");
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", auth.AccessToken);
            var httpResponseMessage = await this.httpClient
                .SendAsync(httpRequestMessage)
                .ConfigureAwait(false);
            var httpResponseContent = await httpRequestMessage.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return;
            }
            throw new InvalidOperationException(httpResponseContent);
        }

    }

}
