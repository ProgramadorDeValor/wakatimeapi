using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WakaTimeWebService.Data.Models
{
    public class AllTimeSinceToday
    {
        [JsonProperty("is_up_to_date")]
        public bool IsUpToDate { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("seconds")]
        public double Seconds { get; set; }
    }
}
