//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

using Karamem0.Preddy.Models.Twitter;
using Karamem0.Preddy.Models.Twitter.Search;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Models
{

    public class TwitterContext
    {

        private readonly HttpClient httpClient;

        private readonly TwitterAuthenticationProvider authenticationProvider;

        public TwitterContext(
            HttpClient httpClient,
            TwitterAuthenticationProvider authenticationProvider)
        {
            this.httpClient = httpClient;
            this.authenticationProvider = authenticationProvider;
        }

        public async Task<TweetSearch?> SearchAsync(
            string query,
            ulong? sinceId = null,
            int? maxResults = null,
            string? nextToken = null)
        {
            var accessToken = await this.authenticationProvider.AquireTokenAsync();
            var httpRequestParameters = new Dictionary<string, string?>()
            {
                ["query"] = query,
                ["expansions"] = "attachments.media_keys,author_id",
                ["media.fields"] = "url",
                ["tweet.fields"] = "attachments,author_id,created_at,id,text",
                ["user.fields"] = "id,name,profile_image_url,username"
            };
            if (sinceId is not null)
            {
                httpRequestParameters["since_id"] = sinceId.ToString();
            }
            if (maxResults is not null)
            {
                httpRequestParameters["max_results"] = maxResults.ToString();
            }
            if (nextToken is not null)
            {
                httpRequestParameters["next_token"] = nextToken;
            }
            var httpRequestUri = QueryHelpers.AddQueryString(
                "https://api.twitter.com/2/tweets/search/recent",
                httpRequestParameters);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, httpRequestUri);
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var httpResponseMessage = await this.httpClient.SendAsync(httpRequestMessage);
            var httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<TweetSearch>(httpResponseContent);
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
