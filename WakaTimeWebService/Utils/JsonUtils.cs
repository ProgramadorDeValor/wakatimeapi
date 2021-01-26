using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;

namespace WakaTimeWebService.Utils
{
    public static class JsonUtils
    {
        public static string GetJsonFromHttpResponse(HttpResponseMessage httpMessage)
        {
            try
            {
                if (!httpMessage.IsSuccessStatusCode)
                {
                    throw new Exception("No Successful Message");
                }
                var task = httpMessage.Content.ReadAsStringAsync();
                Task.WaitAll(task);
                return task.Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static JToken GetJTokenFromRoot(string jsonString, string rootString = "data")
        {
            try
            {
                JToken jToken = JObject.Parse(jsonString).SelectToken(rootString);
                return jToken;
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

    }
}
