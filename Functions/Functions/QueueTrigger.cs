using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Functions.Functions
{
    public static class QueueTrigger
    {
        [FunctionName("QueueTrigger")]
        public static void Run([ServiceBus("inQueue", Connection = "AzureStorageConnection")]
            string myQueueItem,
            [ServiceBus("outQueue", Connection = "ServiceBusConnectionString")]
            IAsyncCollector<dynamic> outputQueue,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            outputQueue.AddAsync(myQueueItem);
        }
    }
}