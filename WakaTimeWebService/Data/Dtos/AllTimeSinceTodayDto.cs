using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using WakaTimeWebService.Data.Models;
using WakaTimeWebService.Utils;

namespace WakaTimeWebService.Data.Dtos
{
    public class AllTimeSinceTodayDto : IConversionDtoSingle<AllTimeSinceToday>
    {
        public AllTimeSinceToday ConvertJsonToObject(string jsonString)
        {

            try
            {
                var jToken = JsonUtils.GetJTokenFromRoot(jsonString); 
                AllTimeSinceToday result = jToken.ToObject<AllTimeSinceToday>();
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string ConvertObjectToJson(AllTimeSinceToday dataObject)
        {
            return JsonSerializer.Serialize(dataObject);
        }
    }
}
