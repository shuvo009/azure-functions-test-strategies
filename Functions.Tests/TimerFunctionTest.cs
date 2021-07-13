﻿using Functions.Functions;
using Functions.Tests.Setup;
using Xunit;

namespace Functions.Tests
{
    public class TimerFunctionTest
    {
        [Fact]
        public void Timer_should_log_message()
        {
            var logger = (ListLogger) TestFactory.CreateLogger(LoggerTypes.List);
            TimerFunction.Run(null, logger);
            var msg = logger.Logs[0];
            Assert.Contains("C# Timer trigger function executed at", msg);
        }
    }
}