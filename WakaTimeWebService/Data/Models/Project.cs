using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WakaTimeWebService.Data.Models
{
    public class Project
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("total_seconds")]
        public float TotalSeconds { get; set; }
        
        [JsonProperty("percent")]
        public float Percent { get; set; }

        [JsonProperty("digital")]
        public string Digital { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("hours")]
        public int Hours { get; set; }

        [JsonProperty("minutes")]
        public int Minutes { get; set; }
    }
}
