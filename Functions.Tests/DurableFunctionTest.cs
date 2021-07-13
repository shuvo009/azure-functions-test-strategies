using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functions.Functions;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Moq;
using Xunit;

namespace Functions.Tests
{
    public class DurableFunctionTest
    {
        [Fact]
        public async Task Run_Orchectrator()
        {
            var contextMock = new Mock<IDurableOrchestrationContext>();
            contextMock.Setup(context => context.CallActivityAsync<string>("DurableFunction_Hello", "Tokyo")).Returns(Task.FromResult<string>("Hello Tokyo!"));
            contextMock.Setup(context => context.CallActivityAsync<string>("DurableFunction_Hello", "Seattle")).Returns(Task.FromResult<string>("Hello Seattle!"));
            contextMock.Setup(context => context.CallActivityAsync<string>("DurableFunction_Hello", "London")).Returns(Task.FromResult<string>("Hello London!"));
            var result = await DurableFunction.RunOrchestrator(contextMock.Object);
            Assert.Equal("Hello Tokyo!", result[0]);
            Assert.Equal("Hello Seattle!", result[1]);
            Assert.Equal("Hello London!", result[2]);
        }
    }
}
