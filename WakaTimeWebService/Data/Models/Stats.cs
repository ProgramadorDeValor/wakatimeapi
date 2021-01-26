using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WakaTimeWebService.Data.Models
{
    public class Stats
    {
        [JsonProperty("total_seconds")]
        public float TotalSeconds { get; set; }

        [JsonProperty("human_readable_total")] 
        public string HumanReadableTotal { get; set; }

        [JsonProperty("daily_average")]
        public float DailyAverage { get; set; }

        [JsonProperty("human_readable_daily_average")]
        public string HumanReadableDailyAverage { get; set; }

        [JsonProperty("projects")]
        public List<Project> Projects { get; set; }

        [JsonProperty("languages")]
        public List<Language> Languages { get; set; }

    }
}
