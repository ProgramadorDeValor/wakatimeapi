using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using WakaTimeWebService.Utils;

namespace WakaTimeWebService.Services
{
    public class WakaTimeService : IDisposable
    {
        private const string AllTimeSinceTodayUrl = "/api/v1/users/current/all_time_since_today";
        private const string StatsUrl = "/api/v1/users/current/stats/{0}";
        private const string SummariesUrl = "/api/v1/users/current/summaries";
        private const string ProjectsUrl = "/api/v1/users/current/projects";
        private const string GoalsUrl = "/api/v1/users/current/goals";
        private HttpClient _http;

        public enum Stats
        {
            last_7_days,
            last_30_days,
            last_6_months,
            last_year
        };

        public WakaTimeService(HttpClient http)
        {
            _http = http;
        }

        public void Dispose()
        {
            _http.Dispose();
        }

        public async Task<HttpResponseMessage> GetAllTimeSinceToday(string project = null)
        {
            var args = new Dictionary<string, string>
            {
                { "project", project }
            };

            var response = await DoGetRequest(AllTimeSinceTodayUrl, args);

            return response;
        }

        public async Task<HttpResponseMessage> GetStats(Stats stats, string project = "")
        {

            var args = new Dictionary<string, string>
            {
                { "project", project },
            };

            string url = String.Format(StatsUrl, stats.ToString());

            var response = await DoGetRequest(url, args);

            return response;
        }

        public async Task<HttpResponseMessage> GetProjects()
        {
            var response = await DoGetRequest(ProjectsUrl);

            return response;
        }

        public async Task<HttpResponseMessage> GetGoals()
        {
            var response = await DoGetRequest(GoalsUrl);

            return response;
        }

        public async Task<HttpResponseMessage> GetSummaries(
                DateTime starTime,
                DateTime endTime,
                string project = "",
                string branches = "",
                int timeout = 0,
                string writesOnly = "",
                string timezone = ""
            )
        {

            var args = new Dictionary<string, string>
            {
                { "start", starTime.ToIsoString() },
                { "end", endTime.ToIsoString()},
                { "project", project },
                { "branches", branches },
                { "timeout", timeout == 0 ? "" : timeout.ToString()},
                { "writes_only", writesOnly },
                { "timezone", timezone },
                
            };

            var response = await DoGetRequest(SummariesUrl, args);

            return response;
        }

        private async Task<HttpResponseMessage> DoGetRequest(string url, Dictionary<string, string> args = null)
        {
            if (args == null)
            {
                return await _http.GetAsync(url);
            }
            else
            {
                var filtered = args.Where((x) => x.Value?.Trim() != "");

                
                return await _http
                    .GetAsync(QueryHelpers.AddQueryString(url, filtered));
            }
        }

    }
}
