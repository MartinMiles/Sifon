using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sifon.Abstractions.Providers;
using Sifon.ApiClient.Handlers;
using Sifon.Code.Encryption;
using Sifon.Code.Extensions;
using Sifon.Code.Statics;

namespace Sifon.ApiClient.Providers
{
    public class ApiProvider<T> : IApiProvider
    {
        public string UUID => new SaltProvider().UUID;

        #region Exposed public API

        public async Task<U> SendFeedback<T, U>(T t)
        {
            var dict = t.ToDictionary<string>();
            dict.Add("UUID", UUID);

            var content = new FormUrlEncodedContent(dict.AsEnumerable());
            var httpResponseMessage = await MakeApiCall(Settings.Api.HostBase, Settings.Api.Feedback, content);
            return await FetchResult<U>(httpResponseMessage);
        }

        public async Task<U> FindLatestVersion<U>()
        {
            var httpResponseMessage = await MakeGetCall(Settings.Api.HostBase, Settings.Api.UpdateVersion);
            return await FetchResult<U>(httpResponseMessage);
        }

        public async Task<string> SendException(Exception e)
        {
            var dict = new Dictionary<string, string> {
                {"UUID", UUID}, {"Version", Settings.VersionNumber}, {"Message", e.Message}, {"StackTrace", e.StackTrace}
            };

            var content = new FormUrlEncodedContent(dict.AsEnumerable());
            var httpResponseMessage = await MakeApiCall(Settings.Api.HostBase, Settings.Api.SendException, content);
            return await FetchResult<string>(httpResponseMessage);
        }

        #endregion

        #region Private methods

        private async Task<HttpResponseMessage> MakeGetCall(string host, string api)
        {
            var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }) { BaseAddress = new Uri(host) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return await client.GetAsync(api);
        }
        private async Task<HttpResponseMessage> MakeApiCall(string host, string api, FormUrlEncodedContent content)
        {
            var client = new HttpClient(new RetryHandler(new TrafficEncryptionHandler(new HttpClientHandler())));
            client.BaseAddress = new Uri(host);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await client.PostAsync(api, content); 
        }

        private async Task<U> FetchResult<U>(HttpResponseMessage result)
        {
            if (result.IsSuccessStatusCode)
            {
                var resultArray = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<U>(resultArray);
            }
            return default(U);
        }

        #endregion
    }
}
