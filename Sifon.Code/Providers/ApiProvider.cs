using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sifon.Abstractions.Providers;
using Sifon.Code.Extensions;
using Sifon.Code.Statics;

namespace Sifon.Code.Providers
{
    public class ApiProvider<T> : IApiProvider
    {
        public ApiProvider()
        {
        }

        // some code potentially could move up to base provider, and use factory with types pattern matching

        public async Task<U> SendFeedback<T, U>(T t)
        {
            var content = new FormUrlEncodedContent(t.ToDictionary<string>().AsEnumerable());
            var httpResponseMessage = await MakeApiCall(Settings.Api.HostBase, Settings.Api.Feedback, content);
            return await FetchResult<U>(httpResponseMessage);
        }

        public async Task<U> FindLatestVersion<U>()
        {
            var httpResponseMessage = await MakeGetCall(Settings.Api.HostBase, Settings.Api.UpdateVersion);
            return await FetchResult<U>(httpResponseMessage);
        }

        public async Task<HttpResponseMessage> MakeGetCall(string host, string api)
        {
            var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }) { BaseAddress = new Uri(host) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return await client.GetAsync(api);
        }
        public async Task<HttpResponseMessage> MakeApiCall(string host, string api, FormUrlEncodedContent content)
        {
            var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }) { BaseAddress = new Uri(host) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return await client.PostAsync(api, content); 
        }

        public async Task<U> FetchResult<U>(HttpResponseMessage result)
        {
            if (result.IsSuccessStatusCode)
            {
                var resultArray = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<U>(resultArray);
            }
            return default(U);
        }
    }
}
