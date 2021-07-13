using System.Collections.Generic;
using System.Threading.Tasks;
using Functions.Functions;
using Functions.Tests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Xunit;

namespace Functions.Tests
{
    public class HttpTriggerTest
    {
        [Fact]
        public async Task Request_With_Query()
        {
            var logger = TestFactory.CreateLogger();
            var query = new Dictionary<string, StringValues>();
            query.TryAdd("name", "Tom");

            var result = await HttpTrigger.Run(TestFactory.HttpRequestSetup(query, ""), logger);
            var resultObject = (OkObjectResult) result;
            Assert.Equal("Hello, Tom", resultObject.Value);
        }

        [Fact]
        public async Task Request_Without_Query()
        {
            var logger = TestFactory.CreateLogger();
            var query = new Dictionary<string, StringValues>();
            var body = "{\"name\":\"Tom\"}";

            var result = await HttpTrigger.Run(TestFactory.HttpRequestSetup(query, body), logger);
            var resultObject = (OkObjectResult) result;
            Assert.Equal("Hello, Tom", resultObject.Value);
        }

        [Fact]
        public async Task Request_Without_Query_And_Body()
        {
            var logger = TestFactory.CreateLogger();
            var query = new Dictionary<string, StringValues>();
            var body = "";
            var result = await HttpTrigger.Run(TestFactory.HttpRequestSetup(query, body), logger);
            var resultObject = (OkObjectResult) result;
            Assert.Equal(
                "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.",
                resultObject.Value);
        }
    }
}