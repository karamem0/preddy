//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

using Karamem0.Preddy.Models.AzureML;
using Microsoft.Extensions.Options;
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

        private readonly AzureMLOptions options;

        public AzureMLContext(HttpClient httpClient, IOptions<AzureMLOptions> options)
        {
            this.httpClient = httpClient;
            this.options = options.Value;
        }

        public async Task<IEnumerable<KeyValuePair<DateTime, double>>> SearchAsync()
        {
            var httpRequestContent = JsonSerializer.Serialize(new RequestPayload()
            {
                Inputs = new RequestInputs()
                {
                    Input = new RequestValue()
                    {
                        ColumnNames = new[] { "dates" },
                        Values = Enumerable.Range(1, 30)
                            .Select(value => DateTime.Now.Date.AddDays(value))
                            .Select(value => new[] { value.ToString("s") })
                            .ToArray(),
                    }
                },
                GlobalParameters = new RequestGlobalParameters()
            });
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, this.options.Endpoint)
            {
                Content = new StringContent(
                    httpRequestContent,
                    Encoding.UTF8,
                    "application/json")
            };
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.options.ApiKey);
            var httpResponseMessage = await this.httpClient.SendAsync(httpRequestMessage);
            var httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonResult = JsonSerializer.Deserialize<ResponsePayload>(httpResponseContent);
                if (jsonResult?.Results?.Result?.Value?.Values is null)
                {
                    return Enumerable.Empty<KeyValuePair<DateTime, double>>();
                }
                else
                {
                    return jsonResult.Results.Result.Value.Values
                        .Where(item => item is not null && item.Count == 2)
                        .Where(item => item![0] is not null && item![1] is not null)
                        .Select(item => KeyValuePair.Create(
                            DateTime.Parse(item![0]!),
                            double.Parse(item![1]!)
                        ))
                        .ToList();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

    }

}
