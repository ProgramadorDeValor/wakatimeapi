using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakaTimeWebService.Utils;
using Xunit;

namespace XUnitTestWakaTimeWebService.Utils
{
    public class DateTimeExtensionTest
    {
        [Fact]
        public void CanConvertDateToIsoString()
        {
            DateTime date = new DateTime(2020, 01, 31, 10, 10, 10, DateTimeKind.Utc);
            var result = date.ToIsoString();
            Assert.Equal("2020-01-31T10:10:10.0000000Z", result);

        }
    }
}
