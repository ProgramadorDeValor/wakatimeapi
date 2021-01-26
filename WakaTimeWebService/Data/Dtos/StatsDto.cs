using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WakaTimeWebService.Data.Models;
using WakaTimeWebService.Utils;

namespace WakaTimeWebService.Data.Dtos
{
    public class StatsDto : IConversionDtoSingle<Stats>
    {
        public Stats ConvertJsonToObject(string jsonString)
        {
            try
            {
                var jToken = JsonUtils.GetJTokenFromRoot(jsonString);
                Stats result = jToken.ToObject<Stats>();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string ConvertObjectToJson(Stats dataObject)
        {
            return JsonSerializer.Serialize(dataObject);
        }
    }
}
