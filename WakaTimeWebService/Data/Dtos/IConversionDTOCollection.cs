using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WakaTimeWebService.Data.Dtos
{
    interface IConversionDTOCollection<T>
    {
        List<T> ConvertStringToList(string jsonString);

        string ConvertListToJson(List<T> dataList);
    }
}
