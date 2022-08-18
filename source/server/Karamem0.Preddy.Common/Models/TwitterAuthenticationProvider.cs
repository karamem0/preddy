//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Karamem0.Preddy.Models.Twitter;
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

    public class TwitterAuthenticationProvider
    {

        private readonly HttpClient httpClient;

        private readonly TwitterOptions twitterOptions;

        public TwitterAuthenticationProvider(
            HttpClient httpClient,
            IOptions<TwitterOptions> twitterOptions)
        {
            this.httpClient = httpClient;
            this.twitterOptions = twitterOptions.Value;
        }

        public async Task<string?> AquireTokenAsync()
        {
            var credentialsString = $"{this.twitterOptions.ConsumerKey}:{this.twitterOptions.ConsumerSecret}";
            var credentialsBytes = Encoding.UTF8.GetBytes(credentialsString);
            var credentialsBase64String = Convert.ToBase64String(credentialsBytes);
            var httpRequestUri = "https://api.twitter.com/oauth2/token";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, httpRequestUri);
            httpRequestMessage.Content = new FormUrlEncodedContent(
                new Dictionary<string, string?>()
                {
                    ["grant_type"] = "client_credentials"
                }
                .Cast<KeyValuePair<string?, string?>>());
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentialsBase64String);
            var httpResponseMessage = await this.httpClient
                .SendAsync(httpRequestMessage)
                .ConfigureAwait(false);
            var httpResponseContent = await httpResponseMessage.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonResult = JsonSerializer.Deserialize<TwitterToken>(httpResponseContent);
                var accessToken = jsonResult?.AccessToken;
                return accessToken;
            }
            else
            {
                var jsonResult = JsonSerializer.Deserialize<TwitterErrorCollection>(httpResponseContent);
                var errorMessage = jsonResult?.Errors?.Select(error => error.Message).FirstOrDefault();
                throw new InvalidOperationException(errorMessage);
            }
        }

    }

}
