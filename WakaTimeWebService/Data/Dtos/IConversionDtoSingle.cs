using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WakaTimeWebService.Data.Dtos
{
    interface IConversionDtoSingle<T>
    {
        T ConvertJsonToObject(string jsonString);
        string ConvertObjectToJson(T  dataObject);
    }
}
