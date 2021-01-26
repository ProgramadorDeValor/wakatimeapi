using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WakaTimeWebService.Utils;
using Xunit;

namespace XUnitTestWakaTimeWebService.Utils
{
    public class JsonUtilsTest
    {
        [Fact]
        public void CanGetJTokenFromJson()
        {
            var jsonBase = "{\"data\": {\"id\": \"12345\",\"name\": \"John Snow\",\"repository\": \"Testing Repository\"}}";
            var jToken = JsonUtils.GetJTokenFromRoot(jsonBase);

            Assert.True(jToken.HasValues);
            Assert.Equal("12345", jToken["id"]);
            Assert.Equal("John Snow", jToken["name"]);
            Assert.Equal("Testing Repository", jToken["repository"]);

        }

        [Fact]
        public void InvalidJsonThrowsExceptions()
        {
            var jsonBase = "{\"data\": {id\": \"12345\",\"name\": \"John Snow\",\"repository\": \"Testing Repository\"}}";
            Assert.Throws<JsonReaderException>(() => JsonUtils.GetJTokenFromRoot(jsonBase));
        }

        [Fact]
        public void CanGetJsonFromHttpResponse()
        {
            var jsonBase = "{\"data\": {\"id\": \"12345\",\"name\": \"John Snow\",\"repository\": \"Testing Repository\"}}";
            
            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonBase)
            };

            var result = JsonUtils.GetJsonFromHttpResponse(message);
            Assert.Equal(jsonBase, result);
        }

        [Fact]
        public void ErrorResponseThrowsException()
        {
            var jsonBase = "{\"data\": {\"id\": \"12345\",\"name\": \"John Snow\",\"repository\": \"Testing Repository\"}}";

            var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(jsonBase)
            };

            Assert.Throws<Exception>(() => JsonUtils.GetJsonFromHttpResponse(message));
            
        }
    }
}
