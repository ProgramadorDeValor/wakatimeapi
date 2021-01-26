using System;
using System.Collections.Generic;
using System.Text;
using WakaTimeWebService.Utils;
using Xunit;

namespace XUnitTestWakaTimeWebService.Utils
{
    public class StringExtensionTest
    {
        [Fact]
        public void CanConvertStringToBase64()
        {
            var str = "1234";
            var result = str.ToBase64();
            Assert.Equal("MTIzNA==", result);
        }
    }
}
