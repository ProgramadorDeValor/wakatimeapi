using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XUnitTestWakaTimeWebService.Mockery
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private string _expectedResponse;
        private HttpStatusCode _statusCode;

        public MockHttpMessageHandler(string expectedResponse, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            _expectedResponse = expectedResponse;
            _statusCode = statusCode;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseMessage = new HttpResponseMessage(_statusCode)
            {
                Content = new StringContent(_expectedResponse)
            };

            return Task.FromResult(responseMessage);
        }
    }
}
