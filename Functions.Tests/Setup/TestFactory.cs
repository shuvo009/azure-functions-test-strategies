using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using Moq;

namespace Functions.Tests.Setup
{
    public static class TestFactory
    {
        public static HttpRequest HttpRequestSetup(Dictionary<string, StringValues> query, string body)
        {
            var reqMock = new Mock<HttpRequest>();

            reqMock.Setup(req => req.Query).Returns(new QueryCollection(query));
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(body);
            writer.Flush();
            stream.Position = 0;
            reqMock.Setup(req => req.Body).Returns(stream);
            return reqMock.Object;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            var logger = type == LoggerTypes.List
                ? new ListLogger()
                : NullLoggerFactory.Instance.CreateLogger("Null Logger");
            return logger;
        }
    }
}