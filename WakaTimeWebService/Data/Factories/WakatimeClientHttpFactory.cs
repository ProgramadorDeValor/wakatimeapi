using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WakaTimeWebService.Utils;

namespace WakaTimeWebService.Data.Factories
{
    public static class WakatimeClientHttpFactory
    {
        public static HttpClient GetClient(string accessToken, string apiUrl = "https://wakatime.com/")
        {
            accessToken = accessToken.ToBase64();
            var http = new HttpClient
            {
                BaseAddress = new Uri(apiUrl)
            };
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", accessToken);

            return http;
        }
    }
}
