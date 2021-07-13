using Functions.Functions;
using Functions.Tests.Setup;
using Xunit;

namespace Functions.Tests
{
    public class QueueTriggerTest
    {
        [Fact]
        public void Receive_Queue_And_Emit_To_Table()
        {
            var logger = TestFactory.CreateLogger();
            var col = new AsyncCollector<dynamic>();
            var json = "{\"name\": \"tom\"}";
            QueueTrigger.Run(json, col, logger);
            Assert.Equal(json, col.Items[0].ToString());
        }
    }
}