//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Models.AzureML;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Models
{

    public class AzureMLContext
    {

        private readonly HttpClient httpClient;

        private readonly AzureMLOptions azuremlOptions;

        private readonly AuthenticationResult authResult;

        public AzureMLContext(
            HttpClient httpClient,
            AzureMLOptions azuremlOptions,
            IConfidentialClientApplication msalApplication)
        {
            this.httpClient = httpClient;
            this.azuremlOptions = azuremlOptions;
            this.authResult = msalApplication
                .AcquireTokenForClient(new[] { "https://management.azure.com/.default" })
                .ExecuteAsync()
                .GetAwaiter()
                .GetResult();
        }

        public async Task RunPipelineAsync()
        {
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
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.authResult.AccessToken);
            var httpResponseMessage = await this.httpClient
                .SendAsync(httpRequestMessage)
                .ConfigureAwait(false);
            var httpResponseContent = await httpResponseMessage.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return;
            }
            throw new InvalidOperationException(httpResponseContent);
        }

        public async IAsyncEnumerable<AzureMLJob> GetJobsAsync(string? nextUrl = null)
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                string.IsNullOrEmpty(nextUrl)
                    ? "https://management.azure.com" +
                      $"/subscriptions/{this.azuremlOptions.SubscriptionId}" +
                      $"/resourceGroups/{this.azuremlOptions.ResourceGroup}" +
                      "/providers/Microsoft.MachineLearningServices" +
                      $"/workspaces/{this.azuremlOptions.Workspace}" +
                      "/jobs" +
                      "?api-version=2022-10-01"
                    : nextUrl
            );
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.authResult.AccessToken);
            var httpResponseMessage = await this.httpClient
                .SendAsync(httpRequestMessage)
                .ConfigureAwait(false);
            var httpResponseStream = await httpResponseMessage.Content
                .ReadAsStreamAsync()
                .ConfigureAwait(false);
            var httpResponseJson = await JsonSerializer
                .DeserializeAsync<AzureMLJobCollection>(httpResponseStream)
                .ConfigureAwait(false);
            if (httpResponseJson?.Value != null)
            {
                foreach (var item in httpResponseJson.Value)
                {
                    yield return item;
                }
            }
            if (httpResponseJson?.NextLink != null)
            {
                await foreach (var item in this.GetJobsAsync(httpResponseJson.NextLink))
                {
                    yield return item;
                }
            }
        }

        public async Task DeleteJobAsync(string id)
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Delete,
                "https://management.azure.com" +
                $"/subscriptions/{this.azuremlOptions.SubscriptionId}" +
                $"/resourceGroups/{this.azuremlOptions.ResourceGroup}" +
                "/providers/Microsoft.MachineLearningServices" +
                $"/workspaces/{this.azuremlOptions.Workspace}" +
                $"/jobs/{id}" +
                "?api-version=2022-10-01"
            );
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.authResult.AccessToken);
            var httpResponseMessage = await this.httpClient
                .SendAsync(httpRequestMessage)
                .ConfigureAwait(false);
            var httpResponseContent = await httpResponseMessage.Content
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
