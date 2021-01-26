using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WakaTimeWebService.Data.Models;
using WakaTimeWebService.Utils;

namespace WakaTimeWebService.Data.Dtos
{
    public class ProjectDto:IConversionDTOCollection<Project>
    {
        public List<Project> ConvertStringToList(string jsonString)
        {
            try
            {
                var jToken = JsonUtils.GetJTokenFromRoot(jsonString);
                List<Project> result = jToken.ToObject<List<Project>>();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string ConvertListToJson(List<Project> dataList)
        {
            return JsonSerializer.Serialize(dataList);
        }
    }
}
